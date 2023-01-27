import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import { CookieService } from 'ngx-cookie-service';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  selectedSeats: any[] = [];
  normalTickets: number;
  reducedTickets: number;
  //TODO: Select amount of tickets from different types. Do not assign type to seat - assign type to ticket.
  constructor(private cookieService: CookieService, private tservice: TicketService, private route: ActivatedRoute, private router: Router) {
    this.normalTickets = 0;
    this.reducedTickets = 0;
  }
  onBuyClick(event: Event){
    //take the user through a mock payment service page
    this.router.navigate(['/payment']);

    //send unpaid ticket to db
    //once payment succeeds, change to paid
  }
  onReserveClick(event: Event){
    this.reserveTicket()
    this.cookieService.set('reduced', this.reducedTickets.toString())
    this.router.navigate(['/summary']);
  }
  private reserveTicket(){
    let screening_id = this.cookieService.get('screening')
    let seats = this.cookieService.get('seats').split(',')
    let reduced = this.reducedTickets
    this.tservice.createTickets(screening_id, seats, reduced, false)
    console.log(screening_id, seats, reduced)
  }
  ngOnInit() {
    this.selectedSeats = this.cookieService.get('seats').split(',')
  }

}


