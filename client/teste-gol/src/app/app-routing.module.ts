import { FlightsEditComponent } from './flights/flights-edit/flights-edit.component';
import { FlightsNewComponent } from './flights/flights-new/flights-new.component';

import { AuthGuard } from './auht.guard';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightsListComponent } from './flights/flights-list/flights-list.component';


const routes: Routes = [
  { path: '', component: FlightsListComponent , canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'flights-new', component: FlightsNewComponent, canActivate: [AuthGuard]  },
  { path: 'flights-edit/:id', component: FlightsEditComponent, canActivate: [AuthGuard]  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
