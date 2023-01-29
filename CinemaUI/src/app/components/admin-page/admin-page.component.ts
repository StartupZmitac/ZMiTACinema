import { Component, OnInit } from '@angular/core';
import {Seat} from "../../models/seat.model";
import {LocationService} from "../../services/location.service";
import {Location} from "../../models/location.model";
import {customRoom} from "../../models/customRoom";

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {

  locations: Location[] = [];
  selectedLocation: string; //TODO: Correct undefined
  showCreateScreeningRoomForm = false;
  dataInputted = false;
  unavailableSeats: (string | undefined)[] = [];
  createdRoom: customRoom;
  seats: Seat[][] = []
  constructor(private lservice: LocationService) {
    this.selectedLocation="";
    this.createdRoom = { column: 10, row: 10, taken_seats: "", unavailable_seats: "", room_number: 0, _locationName: this.selectedLocation  };
  }

  ngOnInit(): void {
    this.getLocations();
    this.createdRoom.row = 10;
    this.createdRoom.column = 10;
  }
  selectSeat(seat: Seat) {
    seat.selected = !seat.selected;
  }
  getLocations() {
    this.lservice.getLocations()
      .subscribe({
        next: (locations) => {
          this.locations = locations;
        },
        error: (response) => {
          console.log(response);
        }
      });
  }
}
