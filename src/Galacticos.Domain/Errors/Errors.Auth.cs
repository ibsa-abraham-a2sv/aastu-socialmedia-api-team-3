using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Galacticos.Domain.Errors
{
    public static partial class Errors
    {
        public static class Auth
        {
            public static Error WrongCreadital =>
            Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid Credentials");
        }
    }
}