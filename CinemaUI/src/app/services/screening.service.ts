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

  getScreenings(date: string, location: string): Observable<Screening[]>{

    let url = this.baseApiUrl+'/api/Screening';
    let data = {
      date: date,
      location: location
    }
    return this.http.get<Screening[]>(url,{params:data});
  }
  
  
}
