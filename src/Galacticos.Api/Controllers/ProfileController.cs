using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Profile;
using Galacticos.Application.Features.Profile.Request.Queries;
using Galacticos.Application.Features.Profile.Request.Commands;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            GetProfileRequest request = new GetProfileRequest()
            {
                UserId = id
            };
            ErrorOr<ProfileResponseDTO> result = await _mediator.Send(request);

            return result.Match<ActionResult>(
                profileResponseDTO => Ok(profileResponseDTO),
                error => BadRequest(error)
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromForm] EditProfileRequestDTO editProfileRequestDTO)
        {
            EditProfileRequest request = new EditProfileRequest()
            {
                UserId = id,
                EditProfileRequestDTO = editProfileRequestDTO
            };
            ErrorOr<ProfileResponseDTO> result = await _mediator.Send(request);

            return result.Match<ActionResult>(
                profileResponseDTO => Ok(profileResponseDTO),
                error => BadRequest(error)
            );
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            GetAllProfileRequest request = new GetAllProfileRequest();
            ErrorOr<List<ProfileResponseDTO>> result = await _mediator.Send(request);

            return result.Match<ActionResult>(
                profileResponseDTOs => Ok(profileResponseDTOs),
                error => BadRequest(error)
            );
        }

    }
}