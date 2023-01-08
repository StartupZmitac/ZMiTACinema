import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainPageComponent} from "./components/main-page/main-page.component";
import {SeatPickerComponent} from './components/seat-picker/seat-picker.component';
import {CheckoutComponent} from "./components/checkout/checkout.component";
import {CancelTicketComponent} from "./components/cancel-ticket/cancel-ticket.component";

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  { path: 'main-page/:localizationName', component: MainPageComponent },
  { path: 'seat-picker', component: SeatPickerComponent },
  { path: 'checkout', component: CheckoutComponent},
  {path: 'cancel-ticket', component: CancelTicketComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
