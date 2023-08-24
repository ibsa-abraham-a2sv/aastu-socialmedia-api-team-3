using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.Contract.Authentication;
using Galacticos.Application.Features.Auth.Requests.Commands;
using Galacticos.Application.Features.Auth.Requests.Queries;
using Galacticos.Application.Handlers.Queries.Login;
using Galacticos.Application.Services.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Galacticos.Api.Controllers;

[Route("api/auth")]
public class AuthController : ApiController{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        
        return authResult.Match<IActionResult>(
            result => Ok(result),
            error => BadRequest(error)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query) ;

        
        return authResult.Match<IActionResult>(
            result => Ok(result),
            error => BadRequest(error)
        );
    }

}