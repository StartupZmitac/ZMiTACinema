import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Room } from '../models/room.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

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
}
