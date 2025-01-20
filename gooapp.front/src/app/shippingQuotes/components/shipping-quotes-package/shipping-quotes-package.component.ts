import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ShippingQuoteService } from '../../service/shippingQuote.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'goapp-shipping-quotes-package',
  standalone: false,
  templateUrl: './shipping-quotes-package.component.html',
  styleUrl: './shipping-quotes-package.component.css',
})
export class ShippingQuotesPackageComponent {
  frmShippingQuotesPackage: FormGroup;
  showCashOnDelivery: boolean = false;

  constructor(private fb: FormBuilder, private toastr: ToastrService) {
    this.frmShippingQuotesPackage = this.fb.group({
      declaredValue: ['', Validators.required],
      contentPackage: ['', Validators.required],
      long: ['', Validators.required],
      broad: ['', Validators.required],
      high: ['', Validators.required],
      weight: ['', Validators.required],
      quantityPackages: ['', Validators.required],
      cashOnDelivery: ['', Validators.required],
      valueCollect: ['', Validators.required],
      chargeShipping: ['', Validators.required],
    });
  }
}
