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
      { number: 'M1', selected: false },
      { number: 'M2', selected: false },
      { number: 'M3', selected: false },
      { number: 'M4', selected: true },
      { number: 'M5', selected: false },
      { number: 'M6', selected: false },
      { number: 'M7', selected: false },
      { number: 'M8', selected: false },
      { number: 'M9', selected: false },
      // ...
    ],
    [
      { number: 'M1', selected: false },
      { number: 'M2', selected: false },
      { number: 'M3', selected: false },
      { number: 'M4', selected: false },
      { number: 'M5', selected: false },
      { number: 'M6', selected: false },
      { number: 'M7', selected: false },
      { number: 'M8', selected: false },
      { number: 'M9', selected: false },
      // ...
    ],
    [
      { number: 'M1', selected: false },
      { number: 'M2', selected: false },
      { number: 'M3', selected: false },
      { number: 'M4', selected: false },
      { number: 'M5', selected: false },
      { number: 'M6', selected: false },
      { number: 'M7', selected: false },
      { number: 'M8', selected: false },
      { number: 'M9', selected: false },
    ],
    [
      { number: 'M1', selected: false },
      { number: 'M2', selected: false },
      { number: 'M3', selected: false },
      { number: 'M4', selected: false },
      { number: 'M5', selected: false },
      { number: 'M6', selected: false },
      { number: 'M7', selected: false },
      { number: 'M8', selected: false },
      { number: 'M9', selected: false },
    ],
    [
      { number: 'M1', selected: false },
      { number: 'M2', selected: false },
      { number: 'M3', selected: false },
      { number: 'M4', selected: false },
      { number: 'M5', selected: false },
      { number: 'M6', selected: false },
      { number: 'M7', selected: false },
      { number: 'M8', selected: false },
      { number: 'M9', selected: false },
    ],
    [
      { number: 'M1', selected: false },
      { number: 'M2', selected: false },
      { number: 'M3', selected: false },
      { number: 'M4', selected: false },
      { number: 'M5', selected: false },
      { number: 'M6', selected: false },
      { number: 'M7', selected: false },
      { number: 'M8', selected: false },
      { number: 'M9', selected: false },
    ],
    // ...
  ];

  selectSeat(seat: Seat) {
    seat.selected = !seat.selected;
  }
  //TODO: If no seat is selected, make button unavailable.
  onButtonClick(event: Event){
    this.selectedSeats = this.seats
      .flat()
      .filter(seat=>seat.selected)
      .map(seat => seat.number);
    this.router.navigate(['/checkout',this.selectedSeats]);
  }
}

