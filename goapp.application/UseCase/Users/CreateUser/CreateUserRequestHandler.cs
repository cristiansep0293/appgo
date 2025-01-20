using goapp.application.Data;
using goapp.application.dto;
using goapp.domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.useCase.users.createUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Result<CreateUserResponse>>
    {
        IGoAppDbContext _goAppDbContext;
        public CreateUserRequestHandler(IGoAppDbContext goAppDbContext)
        {
            this._goAppDbContext = goAppDbContext;
        }
        
        public async Task<Result<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken) 
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return "El nombre es requerido.";
            }

            if (string.IsNullOrEmpty(request.email))
            {
                return "El email es requerido.";
            }

            if (string.IsNullOrEmpty(request.password))
            {
                return "La contraseña es requerida.";
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password);
            User user = new(request.name, request.email, passwordHash);
            _goAppDbContext.Users.Add(user);
            await _goAppDbContext.SaveChangesAsync(cancellationToken);

            CreateUserResponse result = new CreateUserResponse(user.name, user.email, user.password);
            return result;
        }

    }
}
