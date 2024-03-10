using AutoMarketProject.Application.Users.Commands.RegisterUser;
using AutoMarketProject.Application.Users.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarketProject.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationsController : ControllerBase
{
    // Добавить регистрацию и авторизацию
    private readonly IMediator _mediator;

    public AuthenticationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterCommand(
            request.FullName,
            request.Email,
            request.Password);
        
        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query,
        CancellationToken cancellationToken)
    {
        var tokenResult = await _mediator.Send(query, cancellationToken);

        return tokenResult.IsSuccess ? Ok(tokenResult.Value) : NotFound(tokenResult.Error);
    }
}