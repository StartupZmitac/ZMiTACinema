import {Component, OnInit, SimpleChanges} from '@angular/core';
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
  days = ['2023-01-08','2023-01-09','2023-01-10','2023-01-11','2023-01-12','2023-01-13','2023-01-14'];
  selectedDay = "2023-01-08";

  constructor(private cookieService: CookieService, private service: ScreeningService, private route: ActivatedRoute, private router: Router) {
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['localizationName']) {
      window.location.reload(); //Doesnt reload
    }
  }
  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
    const savedSelectedDay = sessionStorage.getItem('selectedDay');
    if (savedSelectedDay) {
      this.selectedDay = savedSelectedDay;
    }
    this.getScreenings();
    this.cookieService.deleteAll();
  }
  onHourClick(screening: Screening){
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
    this.cookieService.set('screening', screening.screening_ID.toString())
    this.cookieService.set('film', screening.film)
    this.cookieService.set('time', screening.time.toString())
  }
  loadScreeningsAgain(){
    console.log(this.selectedDay);
    console.log(this.currentFilm);
    sessionStorage.setItem('selectedDay', this.selectedDay);
    this.getScreenings();
  }
  getScreenings(){
    if(this.localizationName!= undefined)
    this.service.getScreenings(this.selectedDay, this.localizationName)
    .subscribe({
      next: (screenings) =>{
        this.screenings = screenings;
        console.log("got screenings")
        console.log(screenings.length)
        this.screenings = this.screenings.sort((a, b) => {
          if (a.time < b.time) {
            return -1;
          } else if (a.time > b.time) {
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

