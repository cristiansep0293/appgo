using goapp.application.Configuration;
using goapp.application.Data;
using goapp.application.dto;
using goapp.application.useCase.users.createUser;
using goapp.webApi.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.Users.LoginUser
{
    internal class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, Result<LoginUserResponse>>
    {
        IGoAppDbContext _goAppDbContext;
        private readonly EncryptionSettings _settings;
        public LoginUserRequestHandler(IGoAppDbContext goAppDbContext, IOptions<EncryptionSettings> settings)
        {
            this._goAppDbContext = goAppDbContext;
            this._settings = settings.Value;
        }

        public async Task<Result<LoginUserResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.email))
            {
                return "El email es requerido.";
            }

            if (string.IsNullOrEmpty(request.password))
            {
                return "La contraseña es requerida.";
            }

            var query = await _goAppDbContext.Users
                        .FirstOrDefaultAsync(x => x.email.ToLower().Equals(request.email.ToLower()));

            if (query == null)
            {
                return "Usuario incorrecto.";
            }

            bool passwordIsValid = BCrypt.Net.BCrypt.Verify(request.password, query.password);

            if (!passwordIsValid)
            {
                return "Contraseña incorrrecta.";
            }
            
            string IdUserEncrypt = Encryption.Encrypt(query.Id.ToString(), _settings.Key, _settings.IV);
            LoginUserResponse result = new LoginUserResponse(IdUserEncrypt, query.email, query.password);
            return result;
        }
    }
}
