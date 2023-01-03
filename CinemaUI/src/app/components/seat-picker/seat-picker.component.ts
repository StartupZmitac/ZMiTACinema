import {Component} from '@angular/core';
import { Seat } from 'src/app/models/seat.model';
import {Router} from "@angular/router";

@Component({
  selector: 'seat-picker',
  templateUrl: './seat-picker.component.html',
  styleUrls: ['./seat-picker.component.css']
})
export class SeatPickerComponent {
  constructor(private router:Router) {
  }
  selectedSeats: (string | undefined)[] = [];
  seats: Seat[][] = [
    // An array of rows, each containing an array of seats
    // Test array values.
    [
      { number: 'M1', selected: false, available: true },
      { number: 'M2', selected: false, available: true },
      { number: 'M3', selected: false, available: true },
      { number: 'M4', selected: true , available: false },
      { number: 'M5', selected: false, available: true  },
      { number: 'M6', selected: false, available: true  },
      { number: 'M7', selected: false, available: true  },
      { number: 'M8', selected: false, available: true  },
      { number: 'M9', selected: false, available: true  },
      // ...
    ],
    [
      { number: 'M1', selected: false, available: true },
      { number: 'M2', selected: false, available: true },
      { number: 'M3', selected: false, available: true },
      { number: 'M4', selected: false, available: true },
      { number: 'M5', selected: false, available: true },
      { number: 'M6', selected: false, available: true },
      { number: 'M7', selected: false, available: true },
      { number: 'M8', selected: false, available: true },
      { number: 'M9', selected: false, available: true },
      // ...
    ],
    [
      { number: 'M1', selected: false, available: true },
      { number: 'M2', selected: false, available: true },
      { number: 'M3', selected: false, available: true },
      { number: 'M4', selected: false, available: true },
      { number: 'M5', selected: false, available: true },
      { number: 'M6', selected: false, available: true },
      { number: 'M7', selected: false, available: true },
      { number: 'M8', selected: false, available: true },
      { number: 'M9', selected: false, available: true },
      // ...
    ],
    [
      { number: 'M1', selected: false, available: true },
      { number: 'M2', selected: false, available: true },
      { number: 'M3', selected: false, available: true },
      { number: 'M4', selected: false, available: true },
      { number: 'M5', selected: false, available: true },
      { number: 'M6', selected: false, available: true },
      { number: 'M7', selected: false, available: true },
      { number: 'M8', selected: false, available: true },
      { number: 'M9', selected: false, available: true },
      // ...
    ],
    [
      { number: 'M1', selected: false, available: true },
      { number: 'M2', selected: false, available: true },
      { number: 'M3', selected: false, available: true },
      { number: 'M4', selected: false, available: true },
      { number: 'M5', selected: false, available: true },
      { number: 'M6', selected: false, available: true },
      { number: 'M7', selected: false, available: true },
      { number: 'M8', selected: false, available: true },
      { number: 'M9', selected: false, available: true },
      // ...
    ],
    [
      { number: 'M1', selected: false, available: true },
      { number: 'M2', selected: false, available: true },
      { number: 'M3', selected: false, available: true },
      { number: 'M4', selected: false, available: true },
      { number: 'M5', selected: false, available: true },
      { number: 'M6', selected: false, available: true },
      { number: 'M7', selected: false, available: true },
      { number: 'M8', selected: false, available: true },
      { number: 'M9', selected: false, available: true },
      // ...
    ],
    // ...
  ];

  selectSeat(seat: Seat) {
    if (seat.available)
      seat.selected = !seat.selected;
  }
  onButtonClick(event: Event){
    this.seats.flat()
      .filter(seat=>seat.selected)
      .forEach(seat=>seat.available=false);
    this.selectedSeats = this.seats
      .flat()
      .filter(seat=>seat.selected)
      .map(seat => seat.number);

    this.router.navigate(['/checkout',this.selectedSeats]);
  }
}

