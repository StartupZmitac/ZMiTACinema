import { Component, OnInit } from '@angular/core';
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

}
