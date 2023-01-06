import {Component, OnInit} from '@angular/core';
import { Seat } from 'src/app/models/seat.model';
import {ActivatedRoute, Router} from "@angular/router";
import { Room } from 'src/app/models/room.model';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'seat-picker',
  templateUrl: './seat-picker.component.html',
  styleUrls: ['./seat-picker.component.css'],
  providers: [RoomService]
})
export class SeatPickerComponent implements OnInit {
  constructor(private router:Router,private route: ActivatedRoute, private rservice: RoomService) {
  }
  ngOnInit(): void
  {
    this.route.queryParamMap
    .subscribe((params)=>{
      console.log(params)
      let location = params.get('location')
      let room = params.get('room')
      if(location&&room)
        this.getRoom(location, Number(room))
    })
  }
  //TODO: get these from route
  selectedSeats: (string | undefined)[] = [];
  seats: Seat[][] = []
    // An array of rows, each containing an array of seats
  selectSeat(seat: Seat) {
    if (!seat.isTaken)
      seat.selected = !seat.selected;
  }
  onButtonClick(event: Event){
    this.selectedSeats = this.seats
      .flat()
      .filter(seat=>seat.selected)
      .map(seat => seat.number);
    console.log(this.selectedSeats);
    this.router.navigate(['/checkout'],{
      queryParams: {
        seats: this.selectedSeats.join(',')
      }
    });
  }
  getRoom(localizationName: string, room: number){

    this.rservice.getRoomByNum(Number(room), String(localizationName))
      .subscribe({
        next: (room) => {
          this.createRoom(room);
        },
        error: (response) => {
          console.log(response);
        }
      }
      )

  }
  createRoom(room: Room)
  {
    let temps: Seat[] = [];
    for(var i = 0;i < room.row; i++)
    {
      for(var j = 0;j < room.column; j++)
      {
        temps.push({selected: false, number: i + 'M' + j, isTaken: false, unavailable: true});
      }
      this.seats.push(temps);
      temps = [];
    }

    this.seatsDecode(room.taken_seats, true);
    this.seatsDecode(room.unavailable_seats, false)

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

