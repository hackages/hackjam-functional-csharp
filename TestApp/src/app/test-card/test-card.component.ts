import {
  Component,
  OnInit,
  Input,
  OnDestroy,
  ViewEncapsulation
} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { delay, tap, catchError } from 'rxjs/operators';
import { TestConfig, Response } from '../types';
import { Observable, Subscription, BehaviorSubject, zip, from, of } from 'rxjs';
import { FormControl } from '@angular/forms';
import { isObject } from 'util';
@Component({
  selector: 'app-test-card',
  template: `
    <mat-card>
      <mat-card-header>
        <mat-card-title>{{ config.title }}</mat-card-title>
      </mat-card-header>
      <mat-card-content>
        <mat-grid-list [cols]="cases.length > 1 ? 2 : 1">
          <mat-grid-tile
            *ngFor="let case of cases"
            [class.succeeded]="(case.mode$ | async) === 'succeeded'"
            [class.failed]="(case.mode$ | async) === 'failed'"
            [class.not-run]="(case.mode$ | async) === 'undefined'"
            [matTooltip]="case.tooltip.value"
            matTooltipClass="big-tooltip"
          >
            <mat-spinner
              *ngIf="(case.mode$ | async) === 'running'"
            ></mat-spinner>
          </mat-grid-tile>
        </mat-grid-list>
      </mat-card-content>
      <mat-card-actions
        ><button (click)="onRunClick()" mat-raised-button color="primary">
          Run
        </button></mat-card-actions
      >
    </mat-card>
  `,
  styles: [
    `
      mat-card {
        width: 350px;
      }
      mat-grid-list {
      }
    `,
    `
      .succeeded {
        background: lightgreen;
      }

      .failed {
        background: tomato;
      }

      .not-run {
        background: lightblue;
      }
    `,
    `
      .big-tooltip {
        font-size: 1em;
        white-space: pre-wrap;
      }
    `
  ],
  encapsulation: ViewEncapsulation.None
})
export class TestCardComponent implements OnInit, OnDestroy {
  @Input() config: TestConfig;
  @Input() run$: Observable<boolean>;

  constructor(private httpClient: HttpClient) {}

  testCases: { url: string; result: any }[];
  cases: { tooltip: FormControl; mode$: BehaviorSubject<string> }[];
  subscription: Subscription;
  ngOnInit() {
    this.cases = this.config.cases.map(({ url, result }) => ({
      tooltip: new FormControl(
        `Request : ${url} \n\n Expecting : ${JSON.stringify(result)}`
      ),
      mode$: new BehaviorSubject('undefined')
    }));
    this.subscription = this.run$.subscribe(_ => this.onRunClick());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  onRunClick<T>() {
    this.cases.forEach(async ({ mode$, tooltip }, index) => {
      mode$.next('running');
      const { url, result: expectedResult } = this.config.cases[index];

      tooltip.setValue(
        `Request : ${url} \n\n Expected :\t${JSON.stringify(expectedResult)}`
      );

      const { result, time, ticks } = await this.httpClient
        .get<Response>(`http://localhost:3731/${url}`)
        .pipe(
          catchError(_ => {
            mode$.next('failed');
            return of(null);
          })
        )
        .toPromise();

      tooltip.setValue(
        `Requested : ${url} \n\n Expected :\t${JSON.stringify(
          expectedResult
        )} \n\n Received :\t${JSON.stringify(
          result
        )} \n\n Ticks : ${ticks} \n\n Time (ms) : ${time}`
      );

      if (isObject(result) && this.arraysMatch(result, expectedResult)) {
        mode$.next('succeeded');
        return;
      }

      if (result === expectedResult) {
        mode$.next('succeeded');
      } else {
        mode$.next('failed');
      }
    });
  }

  arraysMatch(arr1, arr2) {
    // Check if the arrays are the same length
    if (arr1.length !== arr2.length) {
      return false;
    }

    // Check if all items exist and are in the same order
    for (let i = 0; i < arr1.length; i++) {
      if (isObject(arr1[i]) || isObject(arr2[i])) {
        if (JSON.stringify(arr1[i]) !== JSON.stringify(arr2[i])) {
          return false;
        }
        continue;
      }
      if (arr1[i] !== arr2[i]) {
        return false;
      }
    }

    // Otherwise, return true
    return true;
  }
}
