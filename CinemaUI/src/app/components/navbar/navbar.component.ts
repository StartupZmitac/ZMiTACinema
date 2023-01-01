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
  }

  getLocations(){
    this.lservice.getLocations()
      .subscribe({
        next: (locations) => {
          this.locations = locations;
        },
        error: (response) => {
          console.log(response);
        }
      })
  }
  setLocalizationName(value: string){
    this.localizationName = value;
    this.router.navigate(['/main-page',this.localizationName]);
  }
}

