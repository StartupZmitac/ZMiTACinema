import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainPageComponent} from "./components/main-page/main-page.component";
import {SeatPickerComponent} from './components/seat-picker/seat-picker.component';

const routes: Routes = [
  {
    path: 'main-page',
    component: MainPageComponent
  },
  {
    path: 'seat-picker',
    component: SeatPickerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
