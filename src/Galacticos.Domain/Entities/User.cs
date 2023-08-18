using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName {set; get; } = null!;
        public string LastName {set; get; } = null!;
        public string UserName {set; get; } = null!;
        public string Email {set; get; } = null!;
        public string Password {set; get; } = null!;
        public string Bio {set; get; } = "";
        public string Picture {set; get; } = "";
    }
}