using FluentValidation;

namespace Galacticos.Application.DTOs.Likes.Validators
{
    public class CreateLikeDtoValidator : AbstractValidator<CreateLikeDto>
    {
        public CreateLikeDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
        
    }
}