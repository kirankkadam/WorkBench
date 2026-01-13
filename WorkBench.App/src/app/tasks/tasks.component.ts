import { Component, signal, OnInit, inject} from '@angular/core';
import { Task } from './interface/task';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { TasksService } from './service/tasks.service';
import { BaseComponent } from '../base/base.component';

@Component({
  selector: 'tasks',
  templateUrl: './tasks.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
})


export class TasksComponent extends BaseComponent implements OnInit {

  Tasks = signal<Task[]>([]);
  IsSubmitting = signal(false);
  private fb = inject(FormBuilder);

  TaskForm = this.fb.group({
    title: ['', [Validators.required, Validators.minLength(3)]],
    description: ['', [Validators.required, Validators.minLength(3)]]
  });

  private _tasksService: TasksService;

  constructor(tasksService: TasksService) {
    super();
    this._tasksService = tasksService;
  }

  ngOnInit() {
    this.getAllTasks();
  }

  getAllTasks(): void {
    this._tasksService.getTasks().subscribe({
      next: (response) => {
        this.Tasks.set(response);
      },
      error: (errResponse) => {
        this.handleError(errResponse);
      }
    });
  }

  onSubmit(): void {
    if (this.TaskForm.valid) {
      this.IsSubmitting.set(true);

      this._tasksService.addNewTask(this.TaskForm.value as any).subscribe({
        next: (newTask) => {
          this.TaskForm.reset();
          this.IsSubmitting.set(false);
          this.getAllTasks();

        },
        error: (errorResponse) => {
          this.handleError(errorResponse);
          this.IsSubmitting.set(false);
        }
      });
    }
  }
}

