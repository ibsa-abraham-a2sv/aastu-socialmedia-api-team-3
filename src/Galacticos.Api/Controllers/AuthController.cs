using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.DTOs.Authentication;
using Galacticos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Galacticos.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase{

    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService){
        _authenticationService = authenticationService;
    }
    

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.UserName,
            request.Password,
            request.Email
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.UserName,
            authResult.Email,
            authResult.Bio,
            authResult.ProfilePicture,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.UserName,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.UserName,
            authResult.Email,
            authResult.Bio,
            authResult.ProfilePicture,
            authResult.Token
        );
        return Ok(response);
    }

}
