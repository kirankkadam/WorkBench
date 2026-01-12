import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { task } from '../interface/task';
import { BaseService } from '../../base/base.service';

@Injectable({
  providedIn: 'root'
})

export class TasksService extends BaseService {
  private _httpClient: HttpClient;

  constructor(
    private httpClient: HttpClient
  ) {
    super();
    this._httpClient = httpClient;
  }

  getTasks(): Observable<task[]> {
    return this._httpClient.get<task[]>(`${this.apiUrl}task/GetAllTasks`);
  }
}
