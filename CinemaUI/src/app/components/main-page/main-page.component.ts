/*import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  localizationName: string | null | undefined;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
  }

}*/
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { Screening } from 'src/app/models/screening.model';
import { ScreeningService } from 'src/app/services/screening.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  time: Date = new Date();
  localizationName: string | null | undefined;
  testLocation: string = "string"
  screenings: Screening[] = [];

  constructor(private service: ScreeningService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
    this.getScreenings()
  }
  onHourClick(event: Event){
    //forward roomnum and location of screening
    this.router.navigate(['/seat-picker']);
  }
  getScreenings(){
    this.service.getScreenings("2022-12-30", "string")
    .subscribe({
      next: (screenings) =>{
        this.screenings = screenings;
        console.log("got screenings")
      },
      error: (response) => {
        console.log(response);
      }
    }
    )
  }
}

