import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Ticket } from 'src/app/models/ticket.model';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  ticketID: string | undefined | null;
  errorMessage: string | undefined;
  seats = ''
  normal = 0
  reduced = 0
  price = 0
  show = false
  constructor(private cookieService: CookieService, private tservice: TicketService, private router:Router, private route: ActivatedRoute) { 
    //pass transaction id from buy/reserve
  }

  ngOnInit(): void {
    this.route.queryParamMap
    .subscribe((params)=>{
      console.log(params.get('ticketId'))
      this.getTicket(params.get('ticketId'))
        
    })
  }
  private getTicket(ticketId:string|null){
    if(ticketId){
      this.ticketID = ticketId
    try{
      this.tservice.getTransaction(ticketId).subscribe(data=>{
        data.forEach(element => {
          this.seats+=element.seat+' '
          if(element.type=="reduced"){
            this.reduced+=1
            this.price+=15}
          else{
            this.normal+=1
            this.price+=30.5
          }
        });
        if(data.length==0)
          this.errorMessage = "This ticket doesn't exist"
        }
        
        )
      }
      catch(err){
        this.errorMessage = "there was an error"
      }
    }
  }

  refreshTicket(){
    if(this.ticketID){
    try{
      this.tservice.getTransaction(this.ticketID).subscribe(data=>{
        data.forEach(element => {
          this.seats+=element.seat+' '
          if(element.type=="reduced"){
            this.reduced+=1
            this.price+=15}
          else{
            this.normal+=1
            this.price+=30.5
          }
          this.show = true
        });
        if(data.length==0)
          this.errorMessage = "This ticket doesn't exist"
        }
        
        )
      }
      catch(err){
        this.errorMessage = "there was an error"
      }
    }
  }
}
