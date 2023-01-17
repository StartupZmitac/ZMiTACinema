import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PricesPageComponent } from './prices-page.component';

describe('PricesPageComponent', () => {
  let component: PricesPageComponent;
  let fixture: ComponentFixture<PricesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PricesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PricesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
