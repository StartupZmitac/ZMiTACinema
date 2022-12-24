import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  locations: string[] = ['Kato', 'Twoja Stara']
  constructor(private http: HttpClient) { }

  getLocations():string[]{
    return this.locations;
  }
}
