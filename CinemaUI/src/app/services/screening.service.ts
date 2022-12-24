import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Screening } from '../models/screening.model';

@Injectable({
  providedIn: 'root'
})
export class ScreeningService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getScreenings(): Observable<Screening[]>{
    return this.http.get<Screening[]>(this.baseApiUrl+'/api/Screening')
  }
}
