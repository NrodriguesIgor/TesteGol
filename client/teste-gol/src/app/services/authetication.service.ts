import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutheticationService {
  private currentUserSubject: BehaviorSubject<any>;
  public currentUser: Observable<any>;



  constructor(private http: HttpClient, private router : Router) {

  }

  public get currentUserValue(): any {
    return localStorage.getItem(environment.TOKEN_KEY)
  }



  login(username, password) {
    return this.http.post<any>(`${environment.baseAddress}/users/token`, { username, password })
      .pipe(map(data => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        this.setToken(data);
      }));
  };

  setToken(userTokenResponse: any) {
    if (!userTokenResponse) {
      return;
    }
    localStorage.setItem(environment.TOKEN_KEY, JSON.stringify(userTokenResponse));
  }

  public logout() {
    localStorage.removeItem(environment.TOKEN_KEY);
    this.router.navigate(['/login']);
  }

}
