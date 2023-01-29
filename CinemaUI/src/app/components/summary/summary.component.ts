import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Ticket } from 'src/app/models/ticket.model';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  ticket: Ticket[] | undefined

  constructor(private cookieService: CookieService, private tservice: TicketService) { 
    //pass transaction id from buy/reserve
  }

  ngOnInit(): void {
    // this.tservice.getTransaction("").subscribe(data=>
    //   this.ticket = data
    // )
  }
}
