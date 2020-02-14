import { AutheticationService } from './../services/authetication.service';
import { Injectable } from '@angular/core';
import {
   HttpInterceptor,
   HttpRequest,
   HttpResponse,
   HttpHandler,
   HttpEvent,
   HttpErrorResponse
} from '@angular/common/http';

import { Observable, throwError, from } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';


import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

   constructor(
      private authenticationService: AutheticationService,
      private router: Router) { }

   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      let currentUser = JSON.parse(localStorage.getItem(environment.TOKEN_KEY));
      if (currentUser && currentUser.accessToken) {
         request = request.clone({
            setHeaders: {
               Authorization: `Bearer ${currentUser.accessToken}`
            }
         });
      }

      return next.handle(request);
   }
}
