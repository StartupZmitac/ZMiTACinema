import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Room } from '../models/room.model';
import { Guid } from 'guid-typescript';
import { LocationService } from './location.service';
import { customRoom } from '../models/customRoom';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient, private lservice: LocationService) { }

  getRooms(): Observable<Room[]>{
    return this.http.get<Room[]>(this.baseApiUrl+'/api/Room')
  }
  getRoomByNum(number: number, location: string): Observable<Room>{
    let url = this.baseApiUrl+"/api/Room/room-num"
    let data = {
      id: number,
      location: location
    }
    return this.http.get<Room>(url, { params: data })
  }
  addRoom(location: string, unavailableSeats: string, customroom: customRoom){

    this.lservice.getLocation(location).subscribe(
      data=>{
        let room: Room = {
          id: Guid.createEmpty().toString(),
          column: customroom.column,
          row: customroom.row,
          taken_seats: customroom.taken_seats,
          unavailable_seats: customroom.unavailable_seats,
          room_number: customroom.room_number,
          id_location: data.id.toString(),
          _location: [],
          tickets: [],
          screenings: []
        }
        this.http.post<Room>(this.baseApiUrl+'/api/Room', room)
      }
      )

  }

}
