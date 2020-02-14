import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightsEditComponent } from './flights-edit.component';

describe('FlightsEditComponent', () => {
  let component: FlightsEditComponent;
  let fixture: ComponentFixture<FlightsEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightsEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
