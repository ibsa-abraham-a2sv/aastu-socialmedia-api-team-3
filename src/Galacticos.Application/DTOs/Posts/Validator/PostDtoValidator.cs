// using FluentValidation;
// using Galacticos.Application.Persistence.Contracts;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace Galacticos.Application.DTOs.Posts.Validator
// {
//     public class PostDtoValidator : AbstractValidator<PostDto>
//     {
//         private readonly IPostRepository _postRepository;
//         public PostDtoValidator(IPostRepository postRepository)
//         {
//             _postRepository = postRepository;

//             RuleFor(p => p.UserId).NotNull().WithMessage("User not found");
//             RuleFor(p => p.UserId)
//                 .MustAsync(async (id, token) => {
//                     var postExists = await _postRepository.Exists(id);
//                     return postExists;
//                 });
//             RuleFor(p => p.Caption).NotEmpty().When(p => string.IsNullOrEmpty(p.Image));
//             RuleFor(p => p.Image).NotEmpty().When(p => string.IsNullOrEmpty(p.Caption));
//         }
//     }
// }
