import { Component, inject, OnInit } from '@angular/core';
import {
  DestinationInterface,
  ResultInterface,
} from '../../interface/result.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ShippingQuoteService } from '../../service/shippingQuote.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'gooapp-shipping-quotes-route',
  standalone: false,
  templateUrl: './shipping-quotes-route.component.html',
  styleUrl: './shipping-quotes-route.component.css',
})
export class ShippingQuotesRouteComponent {
  frmShippingQuotesRoute: FormGroup;
  shippingQuoteService: ShippingQuoteService = inject(ShippingQuoteService);
  destinations: DestinationInterface[] = [];

  constructor(private fb: FormBuilder, private toastr: ToastrService) {
    this.frmShippingQuotesRoute = this.fb.group({
      originDestination: ['', Validators.required],
      deliveryDestination: ['', Validators.required],
    });
    this.getDestinations();
  }

  getDestinations(): void {
    this.shippingQuoteService.getDestinations().subscribe({
      next: (data) => {
        this.destinations = data.data.destinations;
      },
      error: (data) => {
        this.toastr.error(
          'No se pudo obtener los destinos de origin y entrega.',
          'GoApp'
        );
      },
    });
  }
}
