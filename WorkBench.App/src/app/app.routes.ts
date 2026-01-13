import { Routes } from '@angular/router';
import { PeopleComponent } from './people/people.component';
import { TasksComponent } from './tasks/tasks.component';
import { TimesheetComponent } from './timesheets/timesheets.component';

const Heading = 'WorkBench International - ';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'timesheets',
    pathMatch: 'full'
  },
  {
    path: 'people',
    loadComponent: () => PeopleComponent,
    title: `${Heading}People`
  },
  {
    path: 'tasks',
    loadComponent: () => TasksComponent,
    title: `${Heading}Tasks`
  },
  {
    path: 'timesheets',
    loadComponent: () => TimesheetComponent,
    title: `${Heading}Timesheets`
  }
];
