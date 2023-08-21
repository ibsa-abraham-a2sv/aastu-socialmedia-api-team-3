using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Profile
{
    public class EditProfileRequestDTO
    {
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? Bio { get; init; } = "";
        public string? Picture { get; init; } = "";
    }
}