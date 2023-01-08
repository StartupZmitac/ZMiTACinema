import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cancel-ticket',
  templateUrl: './cancel-ticket.component.html',
  styleUrls: ['./cancel-ticket.component.css']
})
export class CancelTicketComponent implements OnInit {

  ticketId: string | undefined;
  errorMessage: string | undefined;

  constructor() { }

  ngOnInit(): void {
  }
  onSubmit(){

  }
}
