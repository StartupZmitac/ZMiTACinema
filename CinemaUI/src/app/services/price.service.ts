import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Price } from '../models/price.model';

@Injectable({
  providedIn: 'root'
})
export class PriceService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getPrice(type: string): Observable<Price>{

    return this.http.get<Price>(
      this.baseApiUrl+'/api/Price/type?type='+type)//xdd
  }
  getPrices(): Observable<Price[]>{

    return this.http.get<Price[]>(
      this.baseApiUrl+'/api/Price')
  }
}
