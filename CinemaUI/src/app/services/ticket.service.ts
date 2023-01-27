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

  randomIntFromInterval(min: number, max: number) { // min and max included 
    return Math.floor(Math.random() * (max - min + 1) + min)
  }
  generateId(): number {
    return this.randomIntFromInterval(10000,99999);
  }

  createTickets(screening_id: string, seat: string[], reduced: number){
    let self = this
    let id = this.generateId()
    seat.forEach(function (val){
      if(reduced>0){
        self.createTicket(screening_id, val, "reduced", id).subscribe((data)=>{
          console.log(data)
        })
      }
      else{
        self.createTicket(screening_id, val, "normal", id).subscribe((data)=>{
          console.log(data)
        })
      }
      reduced--;
    })
  }

  private createTicket(screening_id: string, seat: string, type: string, id: number): Observable<any> {
    //only send necessary data to backend
    //seat number, type, Screening id
    let ticket: Ticket = {
      id: Guid.createEmpty().toString(),
      transaction_id: id.toString(),
      isChecked: false,
      isPaid: false,
      seat: seat,
      type: type,
      screening_ID: screening_id
    }

    return this.http.post<Ticket>(this.baseApiUrl+'/api/Ticket', ticket)
  }

  deleteTicket(id: string): Observable<any>{
    return this.http.delete<Ticket>(this.baseApiUrl+'/api/Ticket/'+ id)
  }
}