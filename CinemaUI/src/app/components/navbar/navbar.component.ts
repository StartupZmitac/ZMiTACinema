import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  localizationName = 'Katowice';
  constructor(public router: Router) {}

  ngOnInit(): void {
  }
  setLocalizationName(value: string){
    this.localizationName = value;
    this.router.navigate(['/main-page',this.localizationName]);
  }
}

