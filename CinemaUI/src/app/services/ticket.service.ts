import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable} from 'rxjs';
import { Ticket } from '../models/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }
  
  getTickets(): Observable<Ticket[]>{
    return this.http.get<Ticket[]>(this.baseApiUrl+'/api/Ticket')
  }

  createTickets(location: string, room: string, seat: string[], reduced: number){
    let self = this
    seat.forEach(function (val){
      if(reduced>0){
        self.createTicket(location, room, val, 'reduced')
      }
      else{
        self.createTicket(location, room, val, 'normal')
      }
      reduced--;
    })
  }

  private createTicket(location: string, room: string, seat: string, type: string){
    //only send necessary data to backend
    //seat number, type, Screening id
    let req = {
      location: location,
      room: room,
      seat: seat,
      type: type
    }
    console.log(req)
    //this.http.post(this.baseApiUrl+'/api/Ticket', req)
  }
}