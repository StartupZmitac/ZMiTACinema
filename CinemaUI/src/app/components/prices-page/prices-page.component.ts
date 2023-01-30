import { Component, OnInit } from '@angular/core';
import {LocationService} from "../../services/location.service";
import {PriceService} from "../../services/price.service";
import {Price} from "../../models/price.model";

@Component({
  selector: 'app-prices-page',
  templateUrl: './prices-page.component.html',
  styleUrls: ['./prices-page.component.css']
})
export class PricesPageComponent implements OnInit {
  normalTicketPrice: number = 0;
  reducedTicketPrice: number = 0;
  prices: Price[] = [];
  constructor(private lservice: PriceService) { }

  ngOnInit(): void {
    this.getPrices();
  }
  getPrices() {
    this.lservice.getPrices()
      .subscribe({
        next: (Prices) => {
          Prices.forEach(price => {
            if (price.type=="normal")
              this.normalTicketPrice=price.cost;
            else if (price.type=="reduced")
              this.reducedTicketPrice=price.cost;
          })
        },
        error: (response) => {
          console.log(response);
        }
      });
  }
}
