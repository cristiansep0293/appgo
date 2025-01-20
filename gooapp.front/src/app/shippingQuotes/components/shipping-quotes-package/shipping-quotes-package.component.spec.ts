import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingQuotesPackageComponent } from './shipping-quotes-package.component';

describe('ShippingQuotesPackageComponent', () => {
  let component: ShippingQuotesPackageComponent;
  let fixture: ComponentFixture<ShippingQuotesPackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShippingQuotesPackageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippingQuotesPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
