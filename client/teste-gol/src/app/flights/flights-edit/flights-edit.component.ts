import { Flight } from './../../model/flight';
import { Component, OnInit } from '@angular/core';
import { FlightsService } from 'src/app/services/flights.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-flights-edit',
  templateUrl: './flights-edit.component.html',
  styleUrls: ['./flights-edit.component.css']
})
export class FlightsEditComponent implements OnInit {

  public formGroup: FormGroup;
  private flightId : string;

  constructor(
    private flightsService: FlightsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.createFromGroup();
    this.activatedRoute
    .paramMap
    .subscribe(val => {
      this.flightId = val.get('id');
      this.getFlight();
    });
  }

  public save() {
    this.flightsService
      .update(this.formGroup.controls.id.value, this.formGroup.value)
      .subscribe(_ => { this.router.navigate(['/']); })
  }

public createFromGroup(){
  this.formGroup = this.formBuilder.group({
    id: [],
    origin: ['', Validators.required],
    destination: ['', Validators.required],
    departureTime: ['', Validators.required],
    name: ['', Validators.required],
  });
}

  public setValues(flight: Flight) {
    this.formGroup.controls.name.setValue(flight.name);
    this.formGroup.controls.origin.setValue(flight.origin);
    this.formGroup.controls.destination.setValue(flight.destination);
    console.log(flight.departureTime);
    this.formGroup.controls.departureTime.setValue(new Date(flight.departureTime));
    this.formGroup.controls.id.setValue(flight.id);
  }

  public getFlight() {
    this.flightsService
    .getById(this.flightId)
    .subscribe(data => {
      this.setValues(data);
    })
  }

}
