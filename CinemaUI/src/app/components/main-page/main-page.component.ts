import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
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
  currentFilm: string | null | undefined;

  constructor(private cookieService: CookieService, private service: ScreeningService, private route: ActivatedRoute, private router: Router) {
  }
  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
    this.getScreenings();
    this.cookieService.deleteAll();
  }
  onHourClick(event: Event, screening: Screening){
    this.setScreening(screening);
      this.router.navigate(['/seat-picker'],{ queryParams: {
        location: screening.location,
        room: screening.room.toString()
      }});
  }
  setCurrentFilm(film: string) {
    this.currentFilm = film;
  }
  setScreening(screening: Screening){
    console.log(screening)
    this.cookieService.set('room', screening.room.toString())
    this.cookieService.set('location', screening.location)
  }
  getScreenings(){
    if(this.localizationName!= undefined)
    this.service.getScreenings("2023-01-08", this.localizationName)
    .subscribe({
      next: (screenings) =>{
        this.screenings = screenings;
        console.log("got screenings")
        console.log(screenings.length)
        this.screenings = this.screenings.sort((a, b) => {
          if (a.film < b.film) {
            return -1;
          } else if (a.film > b.film) {
            return 1;
          } else {
            return 0;
          }
        });
      },
      error: (response) => {
        console.log(response);
      }
    })
    console.log(this.screenings);
  }
}

