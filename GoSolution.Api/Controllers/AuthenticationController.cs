using GoSolution.Api.Filters;
using GoSolution.Application.Services.Authentication;
using GoSolution.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GoSolution.Api.Controllers;

[ApiController]
[Route("auth")]
[ErrorHandlingFilter]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        var response = new AuthenticationResponse(
            authResult.Employee.Id,
            authResult.Employee.FirstName,
            authResult.Employee.LastName,
            authResult.Employee.Account?.Username ?? "",
            authResult.Token
            );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password);
        var response = new AuthenticationResponse(
            authResult.Employee.Id,
            authResult.Employee.FirstName,
            authResult.Employee.LastName,
            authResult.Employee.Account?.Username ?? "",
            authResult.Token
        );
        return Ok(response);
    }
}