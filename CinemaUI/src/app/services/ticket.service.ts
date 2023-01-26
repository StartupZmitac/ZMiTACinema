import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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
        self.createTicket(screening_id, val, "reduced").subscribe((data)=>{
          console.log(data)
        })
      }
      else{
        self.createTicket(screening_id, val, "normal").subscribe((data)=>{
          console.log(data)
        })
      }
      reduced--;
    })
  }

  private createTicket(screening_id: string, seat: string, type: string): Observable<any> {
    //only send necessary data to backend
    //seat number, type, Screening id
    let ticket: Ticket = {
      id: Guid.createEmpty().toString(),
      isChecked: false,
      isPaid: false,
      seat: seat,
      type: type,
      screening_ID: screening_id
    }

    return this.http.post<Ticket>(this.baseApiUrl+'/api/Ticket', ticket)
  }
}