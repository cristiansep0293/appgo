import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingQuotesRouteComponent } from './shipping-quotes-route.component';

describe('ShippingQuotesRouteComponent', () => {
  let component: ShippingQuotesRouteComponent;
  let fixture: ComponentFixture<ShippingQuotesRouteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShippingQuotesRouteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippingQuotesRouteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
