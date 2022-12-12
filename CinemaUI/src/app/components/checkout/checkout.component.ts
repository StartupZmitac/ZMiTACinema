import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  //TODO: Select amount of tickets from different types. Do not assign type to seat - assign type to ticket.
  constructor() { }

  ngOnInit(): void {
  }

}


