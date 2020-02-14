import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightsNewComponent } from './flights-new.component';

describe('FlightsNewComponent', () => {
  let component: FlightsNewComponent;
  let fixture: ComponentFixture<FlightsNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightsNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightsNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
