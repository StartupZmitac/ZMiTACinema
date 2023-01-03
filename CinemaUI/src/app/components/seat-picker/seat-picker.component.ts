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
   // this.getRoom();
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
    seat.isTaken = !seat.isTaken;
  }
  //TODO: If no seat is selected, make button unavailable.
  onButtonClick(event: Event){
    this.selectedSeats = this.seats
      .flat()
      .filter(seat=>seat.isTaken)
      .map(seat => seat.number);
    this.router.navigate(['/checkout',this.selectedSeats]);
  }

  rooms: Room =
  {
    id: Guid.create(),
    column: 5,
    row: 5,
    taken_seats: "0C0R,1C1R,",
    unavailable_seats: "2C1R,",
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
        this.rooms = room;
        console.log(room.room_number)
        console.log(this.rooms.room_number)
      },
      error:(response) =>{
        console.log(response)
      }
    }
    )

    console.log(this.rooms.room_number)
  }
  createRoom()
  {
    let temps: Seat[] = [];
    for(var i = 0;i < this.rooms.column; i++)
    {
      for(var j = 0;j < this.rooms.row; j++)
      {
        temps.push({number: 'M' + j, isTaken: false, unavailable: true});
      }
      this.seats.push(temps);
      temps = [];
      //this.seats[i][j] = {number: 'M' + i, selected: false, available: true};
    }

    this.seatsDecode(this.rooms.taken_seats, true);
    this.seatsDecode(this.rooms.unavailable_seats, false)

  }


  seatsDecode(toDecode: string, taken: boolean)
  {
    //gada z api i bierze dane o roomie po id (skad id?)
    //this.seats;
    var temp = "";
    var roww = 0;
    var coll = 0;
    for(var i =0; i<toDecode.length ; i++)
    {
      if(!isNaN(Number(toDecode[i]))){ //nie dziala
        temp += toDecode[i];
      }
      else if(toDecode[i] == "C")
      {
        coll = Number(temp);
        temp = "";

      }
      else if(toDecode[i] == "R")
      {
        roww = Number(temp);
        temp = "";
      }
      else if(toDecode[i] == ",")
      {
        if(taken){
          this.seats[coll][roww].isTaken = true;
        }
        else{
          this.seats[coll][roww].unavailable = true;
        }
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

