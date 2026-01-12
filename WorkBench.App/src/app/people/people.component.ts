import { Component, signal, OnInit } from '@angular/core';
import { person } from './interface/person';
import { CommonModule } from '@angular/common';
import { PeopleService } from './service/people.service';
import { BaseComponent } from '../base/base.component';

@Component({
  selector: 'people',
  templateUrl: './people.component.html',
  standalone: true,
  imports: [CommonModule]
})

export class PeopleComponent extends BaseComponent implements OnInit {

  People = signal<person[]>([]);
  IsVisible = signal(false);
  private _peopleService: PeopleService;

  constructor(peopleService: PeopleService) {
    super();
    this._peopleService = peopleService;
  }

  ngOnInit() {
    this._peopleService.getPeople().subscribe({
      next: (response) => {
        this.People.set(response);
      },
      error: (errResponse) => {
        this.handleError(errResponse);
      }
    });
  }
}

