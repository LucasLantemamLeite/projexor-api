using System.Security.Claims;
using Api.Data.Context;
using Api.Features.Users.Auth;
using Api.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Controllers;

[ApiController]
[Route("v1/delete/user")]
[Tags("Delete")]
[Authorize]
public sealed class DeleteUserController(AppDbContext context) : ControllerBase
{
    [HttpDelete]
    public async Task<IActionResult> ExecuteAsync([FromBody] PasswordUserRequest passwordRequest, CancellationToken cancellationToken = default)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        if (!Guid.TryParse(idClaim, out var userId))
            return Unauthorized(new { message = "" });

        var user = await context.Users.SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user is null || !Hasher.VerifyHash(user.Password, passwordRequest.Password))
            return NotFound(new { message = "" });

        context.Users.Remove(user);

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}