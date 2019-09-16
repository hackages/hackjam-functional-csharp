import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SectionConfig } from './types';
import { tap } from 'rxjs/operators';

@Injectable()
export class TestService {
  constructor(private httpClient: HttpClient) {}

  public getAllTests(): Observable<SectionConfig[]> {
    return this.httpClient
      .get<SectionConfig[]>('assets/tests.json')
      .pipe(tap(console.log));
  }
}
