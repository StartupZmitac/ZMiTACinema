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
        self.createTicket({screening_id: screening_id, seat: val, type: "reduced"}).subscribe((data)=>{
          console.log(data)
        })
      }
      else{
        self.createTicket({screening_id: screening_id, seat: val, type: "normal"}).subscribe((data)=>{
          console.log(data)
        })
      }
      reduced--;
    })
  }

  private createTicket(req: {screening_id: string, seat: string, type: string}): Observable<any> {
    //only send necessary data to backend
    //seat number, type, Screening id
    

    console.log("hello "+req)
    return this.http.post<Ticket>(this.baseApiUrl+'/api/Ticket', req)
  }
}