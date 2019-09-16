import { Component, OnInit } from '@angular/core';
import { TestService } from './test.service';
import { SectionConfig } from './types';

@Component({
  selector: 'app-root',
  template: `
    <app-test-suite
      *ngFor="let item of listOfTests"
      [config]="item"
    ></app-test-suite>
  `,
  styles: [
    `
      :host() {
        display: flex;
        justify-content: space-between;
        flex-direction: column;
      }
    `
  ]
})
export class AppComponent implements OnInit {
  public listOfTests: SectionConfig[];
  constructor(private service: TestService) {}
  async ngOnInit(): Promise<void> {
    this.listOfTests = await this.service.getAllTests().toPromise();
  }
}
