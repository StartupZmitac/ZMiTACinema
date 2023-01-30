import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Admin } from '../models/admin.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  authenticate(login: string, password: string): Observable<Admin>{

    let admin: Admin = {
      id: Guid.createEmpty().toString(),
      login: login,
      password: password
    }
    return this.http.post<Admin>(this.baseApiUrl+'/api/Admin/login', admin)
  
  }
}
