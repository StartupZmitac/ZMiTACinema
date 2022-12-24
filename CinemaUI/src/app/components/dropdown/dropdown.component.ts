import { Component, OnInit } from '@angular/core';
import { Location } from 'src/app/models/location.model';
import { LocationService } from 'src/app/services/location.service';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css'],
  providers: [LocationService]
})
export class DropdownComponent implements OnInit {

  locations: Location[] = [];

  constructor(private lservice: LocationService) { }

  ngOnInit(): void {
    this.getLocations();
  }

  getLocations(){
    this.lservice.getLocations()
    .subscribe({
      next: (locations) => {
        console.log(locations);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
