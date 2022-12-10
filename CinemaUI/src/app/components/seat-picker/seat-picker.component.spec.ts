import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatPickerComponent } from './seat-picker.component';

describe('SeatSelectorComponent', () => {
  let component: SeatPickerComponent;
  let fixture: ComponentFixture<SeatPickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatPickerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeatPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
