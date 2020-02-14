import { Flight } from './../model/flight';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Flight[]>(`${environment.baseAddress}/flights`);
  }

  getById(id: string) {
    return this.http.get<Flight>(`${environment.baseAddress}/flights/${id}`);
  }

  delete(id: string) {
    return this.http.delete(`${environment.baseAddress}/flights/${id}`);
  }

  save(flight: Flight){
    return this.http.post<Flight>(`${environment.baseAddress}/flights`,flight);
  }
  
  update(id: string,flight: Flight){
    return this.http.put(`${environment.baseAddress}/flights/${id}`,flight);
  }
}
