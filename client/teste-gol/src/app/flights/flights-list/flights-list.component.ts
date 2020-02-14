import { ConfirmationService } from 'primeng/api';
import { Flight } from './../../model/flight';
import { Component, OnInit } from '@angular/core';
import { FlightsService } from 'src/app/services/flights.service';


@Component({
  selector: 'app-flights-list',
  templateUrl: './flights-list.component.html',
  styleUrls: ['./flights-list.component.css']
})
export class FlightsListComponent implements OnInit {

  public flights: Array<Flight>;
  constructor(
    private flightService: FlightsService,
    private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.getAllFlights();
  }

  public deleteFlight(id: string) {
    this.confirmationService.confirm({
      message: 'Deseja realmente excluir esse vôo?',
      accept: () => {
        this.flightService.delete(id).subscribe(_ => {this.getAllFlights() });
      }
    });
  }

  public getAllFlights(){
    this.flightService.getAll().subscribe(data => { this.flights = data });
  }

}
