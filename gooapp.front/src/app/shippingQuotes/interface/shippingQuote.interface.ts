export interface ShippingQuoteInterface {
  Id: number;
  IdUserEncrypt: string;
  IdOriginDestination: number;
  IdDeliveryDestination: number;
  DeclaredValue: number;
  ContentPackage: string;
  Long: number;
  Broad: number;
  High: number;
  Weight: number;
  QuantityPackages: number;
  CashOnDelivery: boolean;
  ValueCollect: number;
  ChargeShipping: boolean;
}
