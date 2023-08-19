using FluentValidation;

namespace Galacticos.Application.DTOs.Like.Validators
{
    public class LikeDtoValidator : AbstractValidator<LikeDto>
    {
        public LikeDtoValidator()
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