import { Router } from '@angular/router';
import { FlightsService } from './../../services/flights.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-flights-new',
  templateUrl: './flights-new.component.html',
  styleUrls: ['./flights-new.component.css']
})
export class FlightsNewComponent implements OnInit {
  public formGroup: FormGroup;

  constructor(
    private flightsService: FlightsService,
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
   this.formGroup =  this.formBuilder.group({

      origin: ['', Validators.required],
      destination: ['', Validators.required],
      departureTime: ['', Validators.required],
      name: ['', Validators.required],
    });
  }

  public save() {
    this.flightsService
      .save(this.formGroup.value)
      .subscribe(_ => { this.router.navigate(['/']); })
  }

}
