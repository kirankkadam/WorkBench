import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Person } from '../interface/person';
import { BaseService } from '../../base/base.service';

@Injectable({
  providedIn: 'root'
})

export class PeopleService extends BaseService {
  private _httpClient: HttpClient;

  constructor(
    private httpClient: HttpClient
  ) {
    super();
    this._httpClient = httpClient;
  }

  getPeople(): Observable<Person[]> {
    return this._httpClient.get<Person[]>(`${this.apiUrl}person/GetAllPeople`);
  }

  addPerson(newPerson: Person): Observable<any> {
    return this._httpClient.post(`${this.apiUrl}person/AddNewPerson`, newPerson)
  }
}
