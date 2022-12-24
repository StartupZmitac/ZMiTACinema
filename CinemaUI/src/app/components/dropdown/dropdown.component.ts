import { Component, OnInit } from '@angular/core';
import { LocationService } from 'src/app/services/location.service';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css'],
  providers: [LocationService]
})
export class DropdownComponent implements OnInit {

  locations: string[] = [];

  constructor(private lservice: LocationService) { }

  ngOnInit(): void {
  }

  getLocations(){
    this.locations = this.lservice.getLocations();
  }
}
