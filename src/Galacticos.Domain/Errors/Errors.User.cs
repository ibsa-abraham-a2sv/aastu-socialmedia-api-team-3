using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Galacticos.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "DuplicateEmail", description: "Email already exists");

            public static Error InvalidEmail => Error.Validation(code: "InvalidEmail", description: "Email is invalid");
            public static Error PasswordNotMatch => Error.Validation(code: "PasswordNotMatch", description: "Password not match");
        }
    }
}