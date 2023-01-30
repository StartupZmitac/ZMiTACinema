import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Location } from '../models/location.model';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getLocations(): Observable<Location[]>{
    return this.http.get<Location[]>(this.baseApiUrl+'/api/Location')
  }

  getLocation(name: string): Observable<Location>{
    return this.http.get<Location>(this.baseApiUrl+'/api/Location/by-name?name='+name)
  }

  addLocation(name: string): Observable<Location>{
    let location:Location = {
      id: Guid.createEmpty().toString(),
      city: name,
      rooms: []
    }
    return this.http.post<Location>(this.baseApiUrl+'/api/Location', location)
  }
}
