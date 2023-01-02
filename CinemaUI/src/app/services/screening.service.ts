import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Screening } from '../models/screening.model';
import { Location } from '../models/location.model';

@Injectable({
  providedIn: 'root'
})
export class ScreeningService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // getAllScreenings(): Observable<Screening[]>{
  //   return this.http.get<Screening[]>(this.baseApiUrl+'/api/Screening')
  // }

  getScreenings(date: string, location: string): Observable<Screening[]>{

    let url = this.baseApiUrl+'/api/Screening?location=string&date=2022-12-30';
    let data = {
      date: date,
      string: location
    }
    return this.http.get<Screening[]>(url,{params:data});
  }
}
