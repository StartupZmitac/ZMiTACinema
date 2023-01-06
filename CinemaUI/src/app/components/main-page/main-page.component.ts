import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, NavigationExtras, Router} from '@angular/router';
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

  constructor(private service: ScreeningService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
    this.getScreenings()
  }

  onHourClick(event: Event, _room: number, location: string){
    //forward roomnum and location of screening
    // queryParams:{
    //     location: location,
    //     room: _room
    //   }
    //console.log(navigationExtras.queryParams.location, navigationExtras.queryParams.room);
      this.router.navigate(['/seat-picker'],{ queryParams: {
        location: location,
        room: _room.toString()
      }});
  }

  getScreenings(){
    if(this.localizationName!= undefined)
    this.service.getScreenings("2023-01-06", this.localizationName)
    .subscribe({
      next: (screenings) =>{
        this.screenings = screenings;
        console.log("got screenings")
        console.log(screenings.length)
      },
      error: (response) => {
        console.log(response);
      }
    }
    )
  }
}

