/*import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-seat-picker',
  templateUrl: './seat-picker.component.html',
  styleUrls: ['./seat-picker.component.css']
})
export class SeatSelectorComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}*/
import { Component, OnInit } from '@angular/core';
import { Seat } from 'src/app/models/seat.model';

@Component({
  selector: 'app-seat-picker',
  template: `
    <div class="seat-picker">
      <div class="row" *ngFor="let row of seats">
        <div class="seat" *ngFor="let seat of row" [ngClass]="{'selected': seat.selected}" (click)="selectSeat(seat)">
          {{ seat.number }}
        </div>
      </div>
    </div>
  `,
  styles: [`
    .seat-picker {
      display: flex;
      flex-wrap: wrap;
      justify-content: center;
    }
    .row {
      display: flex;
    }
    .seat {
      border: 1px solid #ccc;
      padding: 10px;
      margin: 5px;
      cursor: pointer;
      flex-shrink: 0;
      flex-grow: 0;
      min-width: 50px;
      min-height: 50px;
    }
    .seat + .seat {
      margin-left: 10px;
    }
    .seat.selected {
      background-color: #ddd;
    }
  `]
})
export class SeatPickerComponent implements OnInit {
  seats: Seat[][] = [
    // An array of rows, each containing an array of seats
    [
      { number: 'R1M1', selected: false },
      { number: 'R2M1', selected: false },
      { number: 'R3M1', selected: false },
      // ...
    ],
    [
      { number: 'R1M2', selected: false },
      { number: 'R2M2', selected: false },
      { number: 'R3M2', selected: false },
      // ...
    ],
    [
      { number: 'R1M3', selected: false },
      { number: 'R2M3', selected: false },
      { number: 'R3M3', selected: false },
    ],
    // ...
  ];

  ngOnInit() {
    // Initialize the seat picker with the data for the available seats
  }

  selectSeat(seat: Seat) {
    // Set the selected property of the seat to true
    seat.selected = !seat.selected;
  }
}

