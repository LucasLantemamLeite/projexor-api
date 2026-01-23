using System.Security.Claims;
using Api.Data.Context;
using Api.Features.Users.Auth;
using Api.Features.Users.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Controllers;

[ApiController]
[Route("v1/update/user")]
[Tags("Update")]
[Authorize]
public sealed class UpdateUserController(AppDbContext context) : ControllerBase
{
    [HttpPatch]
    public async Task<IActionResult> ExecuteAsync([FromBody] UpdateUserRequest updateRequest, CancellationToken cancellationToken = default)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        if (!Guid.TryParse(idClaim, out var userId))
            return Unauthorized(new { message = "Id inválido." });

        var user = await context.Users.SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (user is null || !Hasher.VerifyHash(user.Password, updateRequest.Password))
            return Unauthorized(new { message = "Senha incorreta." });

        user.ChangeName(updateRequest.Name is not null
            ? updateRequest.Name
            : user.Name);

        user.ChangEmail(updateRequest.Email is not null
            ? updateRequest.Email
            : user.Email);

        user.ChangePhone(updateRequest.Phone is not null
            ? updateRequest.Phone
            : user.Phone);

        user.ChangePassword(updateRequest.NewPassword is not null
            ? Hasher.GenerateHash(updateRequest.NewPassword)
            : user.Password);

        context.Users.Update(user);

        await context.SaveChangesAsync(cancellationToken);

        return Ok(new { message = "Conta atualizada com sucesso." });
    }
}