import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Task } from '../interface/task';
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

  getTasks(): Observable<Task[]> {
    return this._httpClient.get<Task[]>(`${this.apiUrl}task/GetAllTasks`);
  }

  addNewTask(newTask: Task): Observable<any> {
    return this._httpClient.post(`${this.apiUrl}task/AddNewTask`, newTask);
  }
}
