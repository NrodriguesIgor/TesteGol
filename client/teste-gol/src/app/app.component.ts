import { AutheticationService } from './services/authetication.service';
import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'teste-gol';

  constructor(private authService: AutheticationService) {

  }

  public logout() {
    this.authService.logout();
  }



}
