import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ShippingQuoteComponent } from './view/shipping-quote/shipping-quote.component';
import { ShippingQuotesRouteComponent } from './components/shipping-quotes-route/shipping-quotes-route.component';
import { ShippingQuotesPackageComponent } from './components/shipping-quotes-package/shipping-quotes-package.component';

@NgModule({
  declarations: [ShippingQuoteComponent, ShippingQuotesRouteComponent, ShippingQuotesPackageComponent],
  imports: [HttpClientModule, ReactiveFormsModule, CommonModule],
  exports: [ShippingQuoteComponent],
})
export class ShippingQuoteModule {}
