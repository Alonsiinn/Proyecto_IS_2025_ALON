using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Login
{
    public class LoginException : Exception
    {
        public LoginResult Result;
        public LoginException(LoginResult result)
        {
            Result = result;
        }
        public override string Message => $"Error de login: {Result}";
    }
}
