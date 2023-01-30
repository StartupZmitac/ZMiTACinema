import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainPageComponent} from "./components/main-page/main-page.component";
import {SeatPickerComponent} from './components/seat-picker/seat-picker.component';
import {CheckoutComponent} from "./components/checkout/checkout.component";
import {CancelTicketComponent} from "./components/cancel-ticket/cancel-ticket.component";
import {PaymentComponent} from "./components/payment/payment.component";
import {SummaryComponent} from "./components/summary/summary.component";
import {LoginComponent} from "./components/user-login/user-login.component";
import {AdminPageComponent} from "./components/admin-page/admin-page.component";
import {PricesPageComponent} from "./components/prices-page/prices-page.component";

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  { path: 'main-page/:localizationName', component: MainPageComponent },
  { path: 'seat-picker', component: SeatPickerComponent },
  { path: 'checkout', component: CheckoutComponent},
  { path: 'cancel-ticket', component: CancelTicketComponent},
  { path: 'payment', component: PaymentComponent},
  { path: 'summary', component: SummaryComponent},
  { path: 'user-login' , component: LoginComponent},
  { path: 'admin-page', component: AdminPageComponent},
  { path: 'prices-page', component: PricesPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
