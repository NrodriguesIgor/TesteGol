
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AutheticationService } from './services/authetication.service';
import { HttpClient,HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import { TokenInterceptor } from './interceptors/token.interceptor';

import { FlightsListComponent } from './flights/flights-list/flights-list.component';
import { FlightsNewComponent } from './flights/flights-new/flights-new.component';
import { FlightsEditComponent } from './flights/flights-edit/flights-edit.component';

import {CalendarModule} from 'primeng/calendar';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ConfirmationService} from 'primeng/api';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    FlightsListComponent,
    FlightsNewComponent,
    FlightsEditComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CalendarModule,
    ConfirmDialogModule
    
  ],
  providers: [
    AutheticationService,
    ConfirmationService,
    HttpClient,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
