import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AdminService } from 'src/app/services/admin.service';
import {LocationService} from "../../services/location.service";


@Component({   selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
  providers: [LocationService]})

export class LoginComponent implements OnInit {

  username = ''
  password = ''

  constructor(private aservice: AdminService, private router: Router, private cookieService: CookieService){

  }

  ngOnInit(): void {
    
  }
    
  onSubmit(){

      this.aservice.authenticate(this.username, this.password).subscribe(
        data=>{
          console.log(data)
          this.router.navigate(['/admin-page'])
          this.cookieService.set('admin', "true")
        }
      )

  }

}
