import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { TicketService } from 'src/app/services/ticket.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(private router: Router, private tservice: TicketService,private cookieService: CookieService) {}

  ngOnInit(): void {
  }
  redirectToSummary(event: Event) {
    this.buyTicket()
    this.router.navigate(['/summary']);
  }
  private buyTicket(){
    let screening_id = this.cookieService.get('screening')
    let seats = this.cookieService.get('seats').split(',')
    let reduced = Number.parseInt( this.cookieService.get('reduced'))
    this.tservice.createTickets(screening_id, seats, reduced, true)
    console.log(screening_id, seats, reduced)
  }
}
