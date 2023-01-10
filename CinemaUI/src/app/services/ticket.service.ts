import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { Ticket } from '../models/ticket.model';
import { Screening } from '../models/screening.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }
  
  getTickets(): Observable<Ticket[]>{
    return this.http.get<Ticket[]>(this.baseApiUrl+'/api/Ticket')
  }
  createTicket(screening: Screening, seat: string, type: string){
    //only send necessary data to backend
    //seat number, type, Screening id
    let req = {
      screening: screening.id,
      seat: seat,
      type: type
    }
    this.http.post(this.baseApiUrl+'/api/Ticket', req)
  }
}