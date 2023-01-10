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
    this.reserveTicket()
    this.router.navigate(['/summary']);

    //send unpaid ticket to db
    //once payment succeeds, change to paid
  }
  onReserveClick(event: Event){
    this.reserveTicket()
    this.router.navigate(['/summary']);
  }
  private reserveTicket(){
    let location = this.cookieService.get('location')
    let room = this.cookieService.get('room')
    let seat = this.cookieService.get('seats').split(',')
    let reduced = this.reducedTickets
    this.tservice.createTickets(location, room, seat, reduced)
    console.log(location, room, seat, reduced)
  }
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.selectedSeats = params['seats'].split(',');
    });
  }

}


