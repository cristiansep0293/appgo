import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable, tap } from 'rxjs';
import { ShippingQuoteInterface } from '../interface/shippingQuote.interface';
import {
  DestinationInterface,
  ResultInterface,
} from '../interface/result.interface';

@Injectable({
  providedIn: 'root',
})
export class ShippingQuoteService {
  private URL: string;
  private take: number = 0;
  private skip: number = 0;
  private shippingQuoteData: ShippingQuoteInterface | null;

  constructor(private http: HttpClient) {
    this.URL = environment.apiURL;
    this.shippingQuoteData = null;
  }

  public get loginInfo(): ShippingQuoteInterface {
    return this.shippingQuoteData!;
  }

  public getDestinations() {
    const body = { search:"", take : 0,skip:0 };
    return this.http.post<ResultInterface>(`${this.URL}/Destination`,body).pipe(
      tap((data) => {
        console.log('Destinos fueros obtenidos:', data);
      })
    );
  }

  public createShippingQuote(
    IdUserEncrypt: string | null,
    IdOriginDestination: number,
    IdDeliveryDestination: number,
    DeclaredValue: number,
    ContentPackage: string,
    Long: number,
    Broad: number,
    High: number,
    Weight: number,
    QuantityPackages: number,
    CashOnDelivery: boolean,
    ValueCollect: number,
    ChargeShipping: boolean
  ): Observable<ShippingQuoteInterface> {
    const body = {
      IdUserEncrypt,
      IdOriginDestination,
      IdDeliveryDestination,
      DeclaredValue,
      ContentPackage,
      Long,
      Broad,
      High,
      Weight,
      QuantityPackages,
      CashOnDelivery,
      ValueCollect,
      ChargeShipping,
    };
    return this.http
      .post<ShippingQuoteInterface>(`${this.URL}/ShippingQuote`, body)
      .pipe(
        tap((data) => {
          console.log('ShippingQuote creado:', data);
        })
      );
  }
}
