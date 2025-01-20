using goapp.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.useCase.users.createUser
{
    public record CreateUserResponse(string name, string email, string password);
}
