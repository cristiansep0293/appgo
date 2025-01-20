import { Component, inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ShippingQuotesRouteComponent } from '../../components/shipping-quotes-route/shipping-quotes-route.component';
import { ShippingQuotesPackageComponent } from '../../components/shipping-quotes-package/shipping-quotes-package.component';
import { ShippingQuoteService } from '../../service/shippingQuote.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'goapp-shipping-quote',
  standalone: false,
  templateUrl: './shipping-quote.component.html',
  styleUrl: './shipping-quote.component.css',
})
export class ShippingQuoteComponent {
  frmShippingQuote!: FormGroup;
  shippingQuoteService: ShippingQuoteService = inject(ShippingQuoteService);
  @ViewChild(ShippingQuotesRouteComponent)
  shippingQuotesRouteComponent!: ShippingQuotesRouteComponent;
  @ViewChild(ShippingQuotesPackageComponent)
  shippingQuotesPackageComponent!: ShippingQuotesPackageComponent;

  constructor(private fb: FormBuilder, private toastr: ToastrService) {
    this.frmShippingQuote = this.fb.group({
      route: this.fb.group({}),
      package: this.fb.group({}),
    });
  }

  ngAfterViewInit(): void {
    this.frmShippingQuote.setControl(
      'frmShippingQuotesRoute',
      this.shippingQuotesRouteComponent.frmShippingQuotesRoute
    );

    this.frmShippingQuote.setControl(
      'frmShippingQuotesPackage',
      this.shippingQuotesPackageComponent.frmShippingQuotesPackage
    );
  }

  createShippingQuoteRequest(): void {
    debugger;
    const formData = this.frmShippingQuote.value;
    const frmShippingQuotesRoute = formData.frmShippingQuotesRoute;
    const frmShippingQuotesPackage = formData.frmShippingQuotesPackage;
    this.shippingQuoteService
      .createShippingQuote(
        localStorage.getItem('IdUserEncrypt'),
        frmShippingQuotesRoute.originDestination,
        frmShippingQuotesRoute.deliveryDestination,
        frmShippingQuotesPackage.declaredValue,
        frmShippingQuotesPackage.contentPackage,
        frmShippingQuotesPackage.long,
        frmShippingQuotesPackage.broad,
        frmShippingQuotesPackage.high,
        frmShippingQuotesPackage.weight,
        frmShippingQuotesPackage.quantityPackages,
        frmShippingQuotesPackage.cashOnDelivery,
        frmShippingQuotesPackage.valueCollect,
        frmShippingQuotesPackage.chargeShipping
      )
      .subscribe({
        next: (data) => {
          this.toastr.success('Cotización creada correctamente', 'GoApp');
        },
        error: (err) => {
          debugger;
          if (err.error && err.error.errors && err.error.errors.length > 0) {
            this.toastr.error(err.error.errors[0], 'GoApp');
          }
        },
      });
  }
}
