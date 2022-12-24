import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Location } from '../models/location.model';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  baseApiUrl: string = environment.baseApiUrl;

  //locations: string[] = ['Kato', 'Twoja Stara']
  constructor(private http: HttpClient) { }

  getLocations(): Observable<Location[]>{
    //return this.locations;
    return this.http.get<Location[]>(this.baseApiUrl+'/apiLocation')

  }
}
