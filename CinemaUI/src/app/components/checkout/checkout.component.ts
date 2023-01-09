import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

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
  constructor(private route: ActivatedRoute, private router: Router) {
    this.normalTickets = 0;
    this.reducedTickets = 0;
  }
  onBuyClick(event: Event){
    this.router.navigate(['/payment'],{ queryParams: {
        seats: this.selectedSeats,
        normalTicketsAmount: this.normalTickets,
        reducedTicketsAmount: this.reducedTickets
      }});
  }
  onReserveClick(event: Event, _room: number, location: string){
    this.router.navigate(['/seat-picker'],{ queryParams: {
        location: location,
        room: _room.toString()
      }});
  }
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.selectedSeats = params['seats'].split(',');
    });
  }

}


