import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import {MainPageComponent} from "./components/main-page/main-page.component";
import {SeatPickerComponent} from "./components/seat-picker/seat-picker.component";
import {CheckoutComponent} from "./components/checkout/checkout.component";
import { NavbarComponent } from './components/navbar/navbar.component';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    SeatPickerComponent,
    CheckoutComponent,
    NavbarComponent
  ],
    imports: [
        HttpClientModule,
        BrowserModule,
        AppRoutingModule, // Import the AppRoutingModule here
        RouterModule.forRoot([]),
        FormsModule,
        // Remove the routes from the root module
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
