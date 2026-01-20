using Api.Data.Context;
using Api.Features.Users.Auth;
using Api.Services;
using Api.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Controllers;

[ApiController]
[Tags("Auth")]
[Route("v1/auth/user")]
public sealed class LoginUserController(AppDbContext context) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ExecuteAsync([FromBody] LoginUserRequest loginRequest, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var user = await context.Users.SingleOrDefaultAsync(x => x.Email == loginRequest.Email, cancellationToken);

        if (user is null || !Hasher.VerifyHash(user.Password, loginRequest.Password))
            return Unauthorized(new { message = "Credênciais incorretas." });

        return Ok(new { message = "Login bem sucedido.", token = user.GenerateToken() });
    }
}