import { Component, OnInit, Input } from '@angular/core';
import { SectionConfig } from '../types';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-test-suite',
  template: `
    <div class="test-header">
      <h1>{{ config.category }}</h1>
      <button (click)="onRunAllClick()" mat-raised-button color="primary">
        Run all
      </button>
    </div>
    <div class="test-suite">
      <app-test-card
        *ngFor="let item of config.tests"
        [run$]="runSubjsect"
        [config]="item"
      ></app-test-card>
    </div>
  `,
  styles: [
    `
      :host() {
        margin: 15px;
        background: beige;
      }
    `,
    `
      .test-suite {
        display: flex;
        flex-wrap: wrap;
      }
      .test-suite app-test-card {
        margin: 15px;
      }
    `,
    `
      .test-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
      }
      .test-header h1 {
        margin: 15px;
        font-size: 3em;
        font-family: Roboto;
      }
      .test-header button {
        margin: 15px;
      }
    `
  ]
})
export class TestSuiteComponent implements OnInit {
  @Input() config: SectionConfig;

  runSubjsect: Subject<boolean> = new Subject();
  constructor() {}

  ngOnInit() {
    console.log(this.config);
  }

  onRunAllClick() {
    this.runSubjsect.next(true);
  }
}
