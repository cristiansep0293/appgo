using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.Users.LoginUser
{
    public record LoginUserResponse (string IdUserEncrypt, string email, string password);
}
