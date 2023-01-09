import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-cancel-ticket',
  templateUrl: './cancel-ticket.component.html',
  styleUrls: ['./cancel-ticket.component.css']
})
export class CancelTicketComponent implements OnInit {

  ticketID: string | undefined;
  errorMessage: string | undefined;
  testID: string = "testID";
  ticketIDFound: boolean | undefined;

  constructor(private router: Router) {
    this.ticketIDFound = false;
  }

  ngOnInit(): void {
  }
  onSubmit(){
    if (this.ticketID==this.testID){
      this.ticketIDFound = true;
    }
    else
      this.ticketIDFound = false;
  }
  redirectToStart(event: Event){
    this.router.navigate(['/']);
  }
}
