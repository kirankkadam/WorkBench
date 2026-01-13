import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TimesheetsService } from './service/timesheets.service';
import { Timesheet } from './interface/timesheet';
import { Task } from '../tasks/interface/task';
import { Person } from "../people/interface/person";
import { PeopleService } from '../people/service/people.service';
import { TasksService } from '../tasks/service/tasks.service';

@Component({
  selector: 'timesheets',
  templateUrl: './timesheets.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  styles:[`.background-wr {border-radius:55px; padding: 5px; text-align:center;}`]
})

export class TimesheetComponent implements OnInit {
  private fb = inject(FormBuilder);
  private timesheetsService = inject(TimesheetsService);
  private peopleService = inject(PeopleService);
  private tasksService = inject(TasksService);

  Timesheets = signal<Timesheet[]>([]);
  People = signal<Person[]>([]);
  Tasks = signal<Task[]>([]);
  TimesheetForm: FormGroup;
  MaxDate: string = "";
  MinDate: string = "";

  constructor() {
    this.TimesheetForm = this.fb.group({
      userId: ['', Validators.required],
      taskId: ['', Validators.required],
      executedOn: [new Date().toISOString().split('T')[0], Validators.required],
      hours: ['', [Validators.required, Validators.min(0.5), Validators.max(12)]]
    });
  }

  get f() { return this.TimesheetForm.controls; }

  ngOnInit() {
    this.peopleService.getPeople().subscribe(res => this.People.set(res));
    this.tasksService.getTasks().subscribe(res => this.Tasks.set(res));
    this.timesheetsService.getTimesheets().subscribe(res => this.Timesheets.set(res));


    let dt = new Date();
    let month = dt.getMonth() + 1;
    let maxMonth = month > 10 ? month : "0" + month;
    this.MaxDate = `${dt.getFullYear()}-${maxMonth}-${dt.getDate()}`;
  }

  onSubmit() {
    if (this.TimesheetForm.valid) {
      console.log('Sending to .NET API:', this.TimesheetForm.value);
      // Call your service here: this.dataService.saveTimesheet(this.timesheetForm.value);
    }
  }
}
