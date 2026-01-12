import { Routes } from '@angular/router';
import { PeopleComponent } from './people/people.component';
import { TasksComponent } from './tasks/tasks.component';

const Heading = 'WorkBench International - ';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'people',
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
];
