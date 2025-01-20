using goapp.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.ShippingQuotes.CreateShippingQuote
{
    public record CreateShippingQuoteResponse(int IdUser, int IdOriginDestination, int IdDeliveryDestination, int DeclaredValue, string? ContentPackage, int Long, int Broad, int High, int Weight, int QuantityPackages, bool CashOnDelivery, int ValueCollect, bool ChargeShipping/*, User user*/);
}
