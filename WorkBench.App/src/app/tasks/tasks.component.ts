import { Component, signal, OnInit } from '@angular/core';
import { Task } from './interface/task';
import { CommonModule } from '@angular/common';
import { TasksService } from './service/tasks.service';
import { BaseComponent } from '../base/base.component';

@Component({
  selector: 'tasks',
  templateUrl: './tasks.component.html',
  standalone: true,
  imports: [CommonModule]
})


export class TasksComponent extends BaseComponent implements OnInit {

  Tasks = signal<Task[]>([]);
  private _tasksService: TasksService;

  constructor(tasksService: TasksService) {
    super();
    this._tasksService = tasksService;
  }

  ngOnInit() {
    this._tasksService.getTasks().subscribe({
      next: (response) => {
        this.Tasks.set(response);
      },
      error: (errResponse) => {
        this.handleError(errResponse);
      }
    });
  }
}

