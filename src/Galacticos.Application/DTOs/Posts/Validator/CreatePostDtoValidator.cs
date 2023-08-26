using FluentValidation;
using Galacticos.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Posts.Validator
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostRequestDTO>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(p => p.Caption)
                .NotEmpty()
                .When(p => string.IsNullOrEmpty(p.Image));

            RuleFor(p => p.Image)
                .NotEmpty()
                .When(p => string.IsNullOrEmpty(p.Caption));
        }
    }
}
