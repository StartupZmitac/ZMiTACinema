import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  //TODO: Select amount of tickets from different types. Do not assign type to seat - assign type to ticket.
  constructor(private route: ActivatedRoute, private router: Router) { }
  selectedSeats: any[] = [];

  ngOnInit(): void {
    //this.selectedSeats = this.route.snapshot.paramMap.get('localizationName');
  }

}


