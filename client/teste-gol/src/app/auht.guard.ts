import { environment } from './../environments/environment';

import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';



@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router
    ) { }

    canActivate() {


        const currentUser = JSON.parse(localStorage.getItem(environment.TOKEN_KEY));

        if (currentUser) {
            return true;
        }


        this.router.navigate(['/login']);
        return false;
    }
}