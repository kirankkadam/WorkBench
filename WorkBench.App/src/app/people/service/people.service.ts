import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { person } from '../interface/person';
import { BaseService } from '../../base/base.service';

@Injectable({
  providedIn: 'root'
})

export class PeopleService extends BaseService {
  private _httpClient: HttpClient;

  People: person[] = [];
  constructor(
    private httpClient: HttpClient
  ) {
    super();
    this._httpClient = httpClient;
  }

  getPeople(): Observable<person[]> {
    return this._httpClient.get<person[]>(`${this.apiUrl}person/GetAllPeople`);
  }
}
