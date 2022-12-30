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
  screenings: Screening[] = [];

  constructor(private service: ScreeningService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
  }
  onHourClick(event: Event){
    this.router.navigate(['/seat-picker']);
  }
  getScreenings(){
    this.service.getAllScreenings()
    .subscribe({
      next: (screenings) =>{
        this.screenings = screenings;
      },
      error: (response) => {
        console.log(response);
      }
    }
    )
  }
}

