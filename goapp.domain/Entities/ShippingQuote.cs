using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace goapp.domain.Entities
{
    public class ShippingQuote
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdOriginDestination { get; set; }
        public int IdDeliveryDestination { get; set; }
        public int DeclaredValue { get; set; }
        public string? ContentPackage { get; set; }
        public int Long { get; set; }
        public int Broad { get; set; }
        public int High { get; set; }
        public int Weight { get; set; }
        public int QuantityPackages { get; set; }
        public bool CashOnDelivery { get; set; }
        public int ValueCollect { get; set; }
        public bool ChargeShipping { get; set; }
        public User? User { get; set; }

        public ShippingQuote()
        {
        }

        public ShippingQuote(int IdUser, int IdOriginDestination, int IdDeliveryDestination, int DeclaredValue, string ContentPackage, int Long, int Broad, int High, int Weight, int QuantityPackages, bool CashOnDelivery, int ValueCollect, bool ChargeShipping)
        {
            this.IdUser = IdUser;
            this.IdOriginDestination = IdOriginDestination;
            this.IdDeliveryDestination = IdDeliveryDestination;
            this.DeclaredValue = DeclaredValue;
            this.ContentPackage = ContentPackage;
            this.Long = Long;
            this.Broad = Broad;
            this.High = High;
            this.Weight = Weight;
            this.QuantityPackages = QuantityPackages;
            this.CashOnDelivery = CashOnDelivery;
            this.ValueCollect = ValueCollect;
            this.ChargeShipping = ChargeShipping;

        }
    }
}
