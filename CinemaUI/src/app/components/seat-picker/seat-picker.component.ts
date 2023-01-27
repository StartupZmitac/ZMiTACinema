import {Component, OnInit} from '@angular/core';
import { Seat } from 'src/app/models/seat.model';
import {ActivatedRoute, Router} from "@angular/router";
import { Room } from 'src/app/models/room.model';
import { RoomService } from 'src/app/services/room.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'seat-picker',
  templateUrl: './seat-picker.component.html',
  styleUrls: ['./seat-picker.component.css'],
  providers: [RoomService]
})
export class SeatPickerComponent implements OnInit {
  constructor(private cookieService: CookieService, private router:Router,private route: ActivatedRoute, private rservice: RoomService) {
  }
  ngOnInit(): void
  {
    this.route.queryParamMap
    .subscribe((params)=>{
      console.log(params)
      let location = params.get('location')
      let room = params.get('room')
      
      if(location&&room){

      //check if cookies exist, if not add them here
      if(!(this.cookieService.check('location')&&this.cookieService.check('room'))){
        this.cookieService.set('location',location)
        this.cookieService.set('room', room)
      }
        this.getRoom(location, Number(room))
    }
    })
  }
  selectedSeats: (string | undefined)[] = [];
  seats: Seat[][] = []
    // An array of rows, each containing an array of seats
  selectSeat(seat: Seat) {
    if (!seat.isTaken)
      seat.selected = !seat.selected;
  }
  private setSeats(seats: string){
    this.cookieService.set('seats', seats)
  }
  onButtonClick(event: Event){
    this.selectedSeats = this.seats
      .flat()
      .filter(seat=>seat.selected)
      .map(seat => seat.number);
    this.setSeats(this.selectedSeats.join(','))
    this.router.navigate(['/checkout'],{
      queryParams: {
        seats: this.selectedSeats.join(',')
      }
    });
  }
  private getRoom(localizationName: string, room: number){

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
  private createRoom(room: Room)
  {
    let temps: Seat[] = [];
    for(var i = 0;i < room.row; i++)
    {
      for(var j = 0;j < room.column; j++)
      {
        temps.push({selected: false, number:  i +'R' + j + 'C', isTaken: false, unavailable: false});
      }
      this.seats.push(temps);
      temps = [];
    }
    this.seatsDecode(room.taken_seats, true);
    this.seatsDecode(room.unavailable_seats, false);
  }
  anySeatsSelected(): boolean {
    return this.seats.some(row => row.some(seat => seat.selected));
  }
  private seatsDecode(toDecode: string, taken: boolean)
  {
    var temp = "";
    var roww = 0;
    var coll = 0;
    for(var i =0; i<toDecode.length ; i++)
    {
      if(!isNaN(Number(toDecode[i]))){
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

          this.seats[roww][coll].isTaken = true;
          console.log(this.seats[coll][roww].number);
        }
        else{
          this.seats[roww][coll].unavailable = true;
        }
        //console.log(coll);
        //console.log(roww);
      }
      else
      {
        temp = "";
        roww = 0;
        coll = 0;
      }

    }
    console.log(this.seats);

  }

}

