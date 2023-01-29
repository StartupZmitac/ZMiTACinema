import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { TicketService } from 'src/app/services/ticket.service';

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

  constructor(private router: Router, private tservice: TicketService) {
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

    
    if(this.ticketID)
      this.tservice.deleteTicket(this.ticketID).subscribe(data=>{
        console.log(data)
      })
  }

  redirectToStart(event: Event){
    this.router.navigate(['/']);
  }
}
