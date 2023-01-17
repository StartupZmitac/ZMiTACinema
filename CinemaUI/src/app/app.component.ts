import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CinemaUI';

  constructor(public router: Router) {}
  onButtonClick(event: Event){
    const buttonId = (event.target as HTMLButtonElement).id;
    const buttonValue = (event.target as HTMLButtonElement).value;
      if (buttonId === 'seat-picker-button')//???
        this.router.navigate(['/seat-picker']);
      else
        this.router.navigate(['/main-page',buttonValue]);

  }

}
