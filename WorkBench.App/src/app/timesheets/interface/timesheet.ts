export interface Timesheet {
  id: number;
  userId: number;
  userName: string;
  taskId: number;
  taskTitle: string;
  executedOn: Date;
  hoursWorked: number;
  comment: string;
}
