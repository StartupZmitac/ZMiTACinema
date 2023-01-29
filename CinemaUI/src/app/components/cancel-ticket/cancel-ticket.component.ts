import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import {Router} from "@angular/router";
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-cancel-ticket',
  templateUrl: './cancel-ticket.component.html',
  styleUrls: ['./cancel-ticket.component.css']
})
export class CancelTicketComponent implements OnInit{

  ticketID: string | undefined;
  errorMessage: string | undefined;
  seats = ''
  normal = 0
  reduced = 0
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
    try{
      this.tservice.getTransaction(this.ticketID).subscribe(data=>{
        data.forEach(element => {
          this.seats+=element.seat+' '
          if(element.type=="reduced")
            this.reduced+=1
          else
            this.normal+=1
        });
        if(data.length==0)
          this.errorMessage = "This ticket doesn't exist"
        else
          this.ticketIDFound = true;
      }
      )
    }
    catch(err){
      this.errorMessage = "there was an error"
    }
  }

  cancelTicket(){
    if(this.ticketID)
      this.tservice.deleteTicket(this.ticketID).subscribe(
        data=>{
          console.log(data)
        }
      )
  }

  redirectToStart(event: Event){
    this.router.navigate(['/']);
  }
}
