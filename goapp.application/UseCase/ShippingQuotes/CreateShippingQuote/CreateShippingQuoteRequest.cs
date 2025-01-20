using goapp.application.dto;
using goapp.application.useCase.users.createUser;
using goapp.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.ShippingQuotes.CreateShippingQuote
{
    public record CreateShippingQuoteRequest(string IdUserEncrypt, int IdOriginDestination, int IdDeliveryDestination, int DeclaredValue, string ContentPackage, int Long, int Broad, int High, int Weight, int QuantityPackages, bool CashOnDelivery, int ValueCollect, bool ChargeShipping/*, User user*/) : IRequest<Result<CreateShippingQuoteResponse>>;
}
