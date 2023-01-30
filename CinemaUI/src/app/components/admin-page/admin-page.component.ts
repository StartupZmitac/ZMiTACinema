import { Component, OnInit } from '@angular/core';
import {Seat} from "../../models/seat.model";
import {LocationService} from "../../services/location.service";
import {Location} from "../../models/location.model";
import {customRoom} from "../../models/customRoom";
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {

  locations: Location[] = [];
  selectedLocation: string;
  newLocationName: string;
  showCreateScreeningRoomForm = false;
  dataInputted = false;
  showAddLocalization = false;
  unavailableSeats: (string | undefined)[] = [];
  createdRoom: customRoom;
  seats: Seat[][] = []
  constructor(private rservice: RoomService, private lservice: LocationService,private cookieService: CookieService, private router: Router) {
    this.selectedLocation="";
    this.createdRoom = { column: 10, row: 10, taken_seats: "", unavailable_seats: "", room_number: 0, _locationName: this.selectedLocation  };
    this.newLocationName = "";
  }
  //TODO:ceny
  //TODO:seans
  //TODO:film
  ngOnInit(): void {

    if(!this.cookieService.check('admin'))
      this.router.navigate(['/'])
    
    this.getLocations();
    this.createdRoom.row = 10;
    this.createdRoom.column = 10;
  }
  selectSeat(seat: Seat) {
    seat.selected = !seat.selected;
  }
  generateSeats(){
      let tempSeats: Seat[] = [];
      for(var i = 1;i <= this.createdRoom.row; i++)
      {
        for(var j = 1;j <= this.createdRoom.column; j++)
        {
          tempSeats.push({selected: false, number: i +'R'+ j + 'C', isTaken: false, unavailable: false});
        }
        this.seats.push(tempSeats);
        tempSeats = [];
      }
      this.dataInputted=true;
  }
  parseSelectedIntoUnavailable(){
    console.log(this.seats);
    for(var i = 0;i < this.createdRoom.row; i++)
    {
      for(var j = 0;j < this.createdRoom.column; j++)
      {
        if (this.seats[i][j].selected==true)
          this.unavailableSeats.push(this.seats[i][j].number+",");
      }
    }
    //TODO: Send list of unavailable seats to database and localization name
    console.log(this.unavailableSeats);
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
  addLocation(){
    this.lservice.addLocation(this.newLocationName).subscribe(
      data=>{
        console.log(data)
    })
  }
}
