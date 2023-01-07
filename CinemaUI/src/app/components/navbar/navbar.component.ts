import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { Location } from 'src/app/models/location.model';
import {LocationService} from "../../services/location.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  providers: [LocationService]
})
export class NavbarComponent implements OnInit {
  locations: Location[] = [];
  localizationName = 'Choose city';

  constructor(public router: Router, private lservice: LocationService) {}

  ngOnInit(): void {
    this.getLocations();
    // Check if a city has been saved in local storage
    const savedCity = localStorage.getItem('selectedCity');
    if (savedCity) {
      this.localizationName = savedCity;
    }
  }

  getLocations() {
    this.lservice.getLocations()
      .subscribe({
        next: (locations) => {
          this.locations = locations;
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  setLocalizationName(value: string) {
    this.localizationName = value;
    // Save the selected city to local storage
    localStorage.setItem('selectedCity', value);
    this.router.navigate(['/main-page', this.localizationName]);
  }
}

