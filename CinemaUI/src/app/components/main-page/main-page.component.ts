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

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  localizationName: string | null | undefined;
  films: { title: string, hours: string[] }[] = [
    {
      title: 'Świat według ZMiTAC',
      hours: ['12:30','14:30']
    },
    {
      title: '365 dni warunku',
      hours: ['12:00', '14:00']
    },
    {
      title: 'Nieznajomy z wydziału',
      hours: ['12:00', '14:00']
    },
    {
      title: 'Skazani na EiM',
      hours: ['12:00', '14:00']
    },
    {
      title: 'Poprawka',
      hours: ['12:00', '14:00']
    },
    {
      title: 'Poprawka 2: Zaskoczenie',
      hours: ['12:00', '14:00']
    },
    {
      title: 'Poprawka 3: Urlop dziekański',
      hours: ['12:00', '14:00']
    },
    {
      title: 'Poprawka 4: Ostateczne starcie',
      hours: ['12:00', '14:00']
    },

  ];

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.localizationName = this.route.snapshot.paramMap.get('localizationName');
  }
  onHourClick(event: Event){
    this.router.navigate(['/seat-picker']);
  }
}

