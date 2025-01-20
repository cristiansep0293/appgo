using goapp.application.Configuration;
using goapp.application.Data;
using goapp.application.dto;
using goapp.application.useCase.users.createUser;
using goapp.application.UseCase.Destinations.GetDestinations;
using goapp.domain.Entities;
using goapp.webApi.Utils;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.ShippingQuotes.CreateShippingQuote
{
    public class CreateShippingQuoteRequestHandler : IRequestHandler<CreateShippingQuoteRequest, Result<CreateShippingQuoteResponse>>
    {
        IGoAppDbContext _goAppDbContext;
        private readonly EncryptionSettings _settings;
        public CreateShippingQuoteRequestHandler(IGoAppDbContext goAppDbContext, IOptions<EncryptionSettings> settings)
        {
            this._goAppDbContext = goAppDbContext;
            this._settings = settings.Value;
        }

        public async Task<Result<CreateShippingQuoteResponse>> Handle(CreateShippingQuoteRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.IdUserEncrypt))
            {
                return "El usuario es requerido";
            }

            if (request.IdOriginDestination == 0)
            {
                return "La ciudad de origen es requerida";
            }

            if (request.IdDeliveryDestination == 0)
            {
                return "La ciudad de destino es requerida";
            }

            if (request.DeclaredValue == 0)
            {
                return "El valor declarado es requerido";
            }

            if (string.IsNullOrEmpty(request.ContentPackage))
            {
                return "El contenido del paquete es requerido";
            }

            if (request.Long == 0)
            {
                return "El largo es requerido";
            }

            if (request.Broad == 0)
            {
                return "El ancho es requerido";
            }

            if (request.High == 0)
            {
                return "El alto es requerido";
            }

            if (request.Weight == 0)
            {
                return "El peso es requerido";
            }

            if (request.QuantityPackages == 0)
            {
                return "La cantidad de paquetes es requerida";
            }

            int IdUserDecrypt = int.Parse(Encryption.Decrypt(request.IdUserEncrypt, _settings.Key, _settings.IV));
            ShippingQuote shippingQuote = new(IdUserDecrypt, request.IdOriginDestination, request.IdDeliveryDestination, request.DeclaredValue, request.ContentPackage, request.Long, request.Broad, request.High, request.Weight, request.QuantityPackages, request.CashOnDelivery, request.ValueCollect, request.ChargeShipping);
            _goAppDbContext.ShippingQuotes.Add(shippingQuote);
            await _goAppDbContext.SaveChangesAsync(cancellationToken);

            CreateShippingQuoteResponse result = new CreateShippingQuoteResponse(shippingQuote.IdUser, shippingQuote.IdOriginDestination, shippingQuote.IdDeliveryDestination, shippingQuote.DeclaredValue, shippingQuote.ContentPackage, shippingQuote.Long, shippingQuote.Broad, shippingQuote.High, shippingQuote.Weight, shippingQuote.QuantityPackages, shippingQuote.CashOnDelivery, shippingQuote.ValueCollect, shippingQuote.ChargeShipping/*, shippingQuote.User*/);
            return result;
        }
    }
}
