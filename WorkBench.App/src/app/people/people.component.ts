import { Component, signal, OnInit, inject } from '@angular/core';
import { Person } from './interface/person';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { PeopleService } from './service/people.service';
import { BaseComponent } from '../base/base.component';

@Component({
  selector: 'people',
  templateUrl: './people.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
})

export class PeopleComponent extends BaseComponent implements OnInit {

  People = signal<Person[]>([]);
  IsVisible = signal(false);
  IsSubmitting = signal(false);
  private fb = inject(FormBuilder);

  PersonForm = this.fb.group({
    fullName: ['', [Validators.required, Validators.minLength(3)]]
  });

  private _peopleService: PeopleService;

  constructor(peopleService: PeopleService) {
    super();
    this._peopleService = peopleService;
  }

  ngOnInit() {
    this.getPeople();
  }

  getPeople(): void {
    this._peopleService.getPeople().subscribe({
      next: (response) => {
        this.People.set(response);
      },
      error: (errorResponse) => {
        this.handleError(errorResponse);
      }
    });
  }

  onSubmit(): void {
    if (this.PersonForm.valid) {
      this.IsSubmitting.set(true);

      this._peopleService.addPerson(this.PersonForm.value as any).subscribe({
        next: (newPerson) => {
          console.log('Person added:', newPerson);
          this.PersonForm.reset();
          this.IsSubmitting.set(false);
          this.getPeople();

        },
        error: (errorResponse) => {
          this.handleError(errorResponse);
          this.IsSubmitting.set(false);
        }
      });
    }
  }
}

