using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Features.Comments.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Galacticos.Api.Controllers
{
    [Route("api/comment")]
    public class CommentController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CommentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Guid PostId, Guid UserId, [FromBody] CreateCommentRequestDTO request)
        {
            var command = _mapper.Map<CreateCommentCommand>(request);
            command.PostId = PostId;
            command.UserId = UserId;
            var res = await _mediator.Send(command);

            return res.Match<IActionResult>(
                error => BadRequest(error),
                comment => Ok(comment)
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentById(Guid Id)
        {
            var res = await _mediator.Send(new GetCommentByIdRequest {Id = Id});

            return res.Match<IActionResult>(
                error => BadRequest(error),
                comment => Ok(comment)
            );
        }

        [HttpGet("{PostId}")]
        public async Task<IActionResult> GetCommentsByPostId(Guid PostId)
        {
            var res = await _mediator.Send(new GetCommentsByPostIdRequest {PostId = PostId});
            
            Console.WriteLine("CommentController: "+res.ToString());
            return res.Match<IActionResult>(
                error => BadRequest(error),
                comments => Ok(comments)
            );
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Guid Id, [FromBody] UpdateCommentRequestDTO request)
        {
            var command = _mapper.Map<UpdateCommentCommand>(request);
            command.Id = Id;
            var res = await _mediator.Send(command);

            return res.Match<IActionResult>(
                error => BadRequest(error),
                comment => Ok(comment)
            );
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(Guid Id)
        {
            var res = await _mediator.Send(new DeleteCommentRequest {Id = Id});

            return res.Match<IActionResult>(
                error => BadRequest(error),
                comment => Ok(comment)
            );
    }
}   
}

// 3fa85f64-5717-4562-b3fc-2c963f66afa5