import {Component, OnInit} from '@angular/core';
import { Seat } from 'src/app/models/seat.model';
import {Router} from "@angular/router";
import { Room } from 'src/app/models/room.model';
import { Guid } from 'guid-typescript';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'seat-picker',
  templateUrl: './seat-picker.component.html',
  styleUrls: ['./seat-picker.component.css'],
  providers: [RoomService]
})
export class SeatPickerComponent implements OnInit {
  constructor(private router:Router, private rservice: RoomService) {
  }
  ngOnInit(): void
  {
    this.getRoom();
    this.createRoom();

  }
  //TODO: get these from route
  locationName: string = "Miechów";
  roomNum: number = 0;

  selectedSeats: (string | undefined)[] = [];
  seats: Seat[][] = [
    // An array of rows, each containing an array of seats
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
  
  rooms: Room = 
  {
    id: Guid.create(),
    column: 2,
    row: 3,
    taken_seats: "1C2R,2C3R",
    unavailable_seats: "1C1R",
    room_number: 5,
    id_location: Guid.create(),
    _location: [],
    tickets: [],
    screenings: []  
  }
  getRoom(){
    this.rservice.getRoomByNum(this.roomNum,this.locationName)
    .subscribe({
      next: (room) => {
        this.rooms = room
      },
      error:(response) =>{
        console.log(response)
      }
    }
    )
  }
  createRoom()
  {
    let temps: Seat[] = [];
    for(var i = 0;i < this.rooms.column; i++)
    {
      for(var j = 0;j < this.rooms.row; j++)
      {
        temps.push({number: 'M' + j, selected: false, available: true});
      }
      this.seats.push(temps);
      temps = [];
      //this.seats[i][j] = {number: 'M' + i, selected: false, available: true};
    }
    
    console.log("dziala createroom");
    this.takenSeatsDecode();

  }

  takenSeatsDecode()
  {
    //gada z api i bierze dane o roomie po id (skad id?)
    //this.seats;
    var temp = "";
    var roww = 0;
    var coll = 0;
    for(var i =0; i<this.rooms.taken_seats.length; i++)
    {
      if(!isNaN(Number(this.rooms.taken_seats[i]))){ //nie dziala
        temp += this.rooms.taken_seats[i];
      }
      else if(this.rooms.taken_seats[i] == "C") 
      {
        coll = Number(temp);
        temp = "";

      }
      else if(this.rooms.taken_seats[i] == "R")
      {
        roww = Number(temp);
        temp = "";
      }
      else if(this.rooms.taken_seats[i] == ",")
      {
        this.seats[coll][roww].selected = true;
        console.log(coll);
        console.log(roww);
      }
      else
      {
        var temp = "";
        var roww = 0;
        var coll = 0;
      } 
        
    }

  }


}

