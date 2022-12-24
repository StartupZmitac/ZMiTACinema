import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  locations: string[] = ['Kato', 'Twoja Stara']
  constructor() { }

  getLocations():string[]{
    return this.locations;
  }
}
