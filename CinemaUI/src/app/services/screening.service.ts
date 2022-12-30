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

  getAllScreenings(): Observable<Screening[]>{
    return this.http.get<Screening[]>(this.baseApiUrl+'/api/Screening')
  }

  getScreenings(date: Date, location: Location): Observable<Screening[]>{

    let url = this.baseApiUrl+'/api/Screening';
    let params= new HttpParams();
    params.append(location.city,date.toString());
    return this.http.get<Screening[]>(url,{params})
  }
}
