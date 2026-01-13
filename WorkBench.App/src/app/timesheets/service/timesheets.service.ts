import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Timesheet } from '../interface/timesheet';
import { BaseService } from '../../base/base.service';

@Injectable({
  providedIn: 'root'
})

export class TimesheetsService extends BaseService {
  private _httpClient: HttpClient;

  constructor(
    private httpClient: HttpClient
  ) {
    super();
    this._httpClient = httpClient;
  }

  getTimesheets(): Observable<Timesheet[]> {
    return this._httpClient.get<Timesheet[]>(`${this.apiUrl}timesheet/GetAllTimesheets`);
  }

  addTimesheet(timesheet: Timesheet): Observable<any> {
    return this._httpClient.post(`${this.apiUrl}timesheet/AddTimesheet`, timesheet);
  }

  deleteTimesheet(timesheetId: number): Observable<any> {
    return this._httpClient.delete(`${this.apiUrl}timesheet/DeleteTimesheet?timesheetId=${timesheetId}`);
  }
}
