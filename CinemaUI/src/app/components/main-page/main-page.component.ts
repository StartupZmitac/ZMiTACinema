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
  currentFilm: string | null | undefined;

  constructor(private service: ScreeningService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
    this.getScreenings();

  }

  onHourClick(event: Event, _room: number, location: string){
      this.router.navigate(['/seat-picker'],{ queryParams: {
        location: location,
        room: _room.toString()
      }});
  }
  setCurrentFilm(film: string) {
    this.currentFilm = film;
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

