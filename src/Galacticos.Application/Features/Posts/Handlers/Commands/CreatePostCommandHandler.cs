using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.DTOs.Posts.Validator;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Domain.Errors;
using MediatR;

namespace Galacticos.Application.Features.Posts.Handlers.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<PostResponesDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly IPostTagRepository _postTagRepository;

        private readonly IUserRepository _userRepository;

        public CreatePostCommandHandler(
            IPostRepository postRepository,
            IMapper mapper,
            ITagRepository tagRepository,
            IPostTagRepository postTagRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<PostResponesDTO>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Exists(request.UserId);

            var validator = new CreatePostDtoValidator();
            var obj = new CreatePostRequestDTO()
            {
                Caption = request.Caption,
                Image = request.Image
            };
            var result = validator.Validate(obj);

            if (!result.IsValid)
            {
                return new ErrorOr<PostResponesDTO>().Errors;
            }

            if (user == false)
            {
                return new ErrorOr<PostResponesDTO>().Errors;
            }
            
            var post = _mapper.Map<Post>(request);

            var postResult = await _postRepository.Add(post);

            if (postResult == null)
            {
                return new ErrorOr<PostResponesDTO>().Errors; // Assuming this returns an ErrorOr instance with appropriate error
            }

            var caption = request.Caption;
            var regex = new Regex(@"#\w+");

            var hashtags = regex.Matches(caption).Select(x => x.Value).ToList();

            

            var tags = new List<Tag>();

            foreach (var hashtag in hashtags)
            {
                var tag = await _tagRepository.GetTagByName(hashtag);
                if (tag == null)
                {
                    tag = new Tag { Name = hashtag };
                    await _tagRepository.Add(tag);
                }

                tags.Add(tag);
            }

            foreach (var hashtag in tags)
            {
                var tag = await _tagRepository.GetTagByName(hashtag.Name);
                if (tag != null){
                    var postTag = new PostTag { PostId = postResult.Id, TagId = tag.Id };
                    await _postTagRepository.Add(postTag);
                }
                else{
                    tag = new Tag { Name = hashtag.Name };
                    await _tagRepository.Add(tag);
                    var postTag = new PostTag { PostId = postResult.Id, TagId = tag.Id };
                    await _postTagRepository.Add(postTag);
                }
            }


            var response = _mapper.Map<PostResponesDTO>(postResult);
            
            return response;
        }
    }
}