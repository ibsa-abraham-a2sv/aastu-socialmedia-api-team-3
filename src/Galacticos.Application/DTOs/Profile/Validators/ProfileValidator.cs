using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Galacticos.Application.DTOs.Profile.Validators
{
    public class ProfileValidator : AbstractValidator<EditProfileRequestDTO>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(50)
                .WithMessage("First name cannot be longer than 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(50)
                .WithMessage("Last name cannot be longer than 50 characters");

            RuleFor(x => x.Bio)
                .MaximumLength(500)
                .WithMessage("Bio cannot be longer than 500 characters");

            RuleFor(x => x.Picture)
                .MaximumLength(500)
                .WithMessage("Picture cannot be longer than 500 characters");
        }
        
    }
}