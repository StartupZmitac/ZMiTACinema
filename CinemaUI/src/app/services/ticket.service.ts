import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { Ticket } from '../models/ticket.model';
import { Screening } from '../models/screening.model';
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
  createTicket(screening: Screening, seat: string, type: string){

    let req: Ticket = {
      id: Guid.create(),
      isChecked: false,
      film: screening.film,
      isPaid: false,
      room: screening.room,
      //todo: multiple seats on one ticket
      seat: seat,
      type: type,
      time: screening.time,
      id_room: screening.id_room,
      //is this necessary?
      _room: screening._room

    }
    this.http.post(this.baseApiUrl+'/api/Ticket', req)
  }
}