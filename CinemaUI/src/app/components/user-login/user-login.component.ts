import { Component, OnInit } from '@angular/core';
import {LocationService} from "../../services/location.service";


@Component({   selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
  providers: [LocationService]})

export class LoginComponent implements OnInit {

  constructor(){

  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
    
  onSubmit(){
    
  }

}
