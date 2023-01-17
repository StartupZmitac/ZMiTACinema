import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable} from 'rxjs';
import { Ticket } from '../models/ticket.model';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }
  
  getTickets(): Observable<Ticket[]>{
    return this.http.get<Ticket[]>(this.baseApiUrl+'/api/Ticket')
  }

  createTickets(screening_id: string, seat: string[], reduced: number){
    let self = this
    seat.forEach(function (val){
      if(reduced>0){
        self.createTicket(screening_id, val, 'reduced')
      }
      else{
        self.createTicket(screening_id, val, 'normal')
      }
      reduced--;
    })
  }

  private createTicket(screening_id: string, seat: string, type: string){
    //only send necessary data to backend
    //seat number, type, Screening id
    let req = {
      screening_id: screening_id,
      seat: seat,
      type: type
    }
    console.log(req)
    //this.http.post(this.baseApiUrl+'/api/Ticket', req)
  }
}