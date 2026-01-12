import { Component } from "@angular/core";
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'base',
  template: '<div></div>',
  standalone:true
})

export class BaseComponent {
  handleError(errorResponse: HttpErrorResponse): void {
    if (errorResponse.status === 401) {
      console.log('There is an error ' + errorResponse);
    }
  }
}
