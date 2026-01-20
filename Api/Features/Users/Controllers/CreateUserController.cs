using Api.Data.Context;
using Api.Features.Users.Auth;
using Api.Features.Users.Models;
using Api.Features.Users.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Controllers;

[ApiController]
[Tags("Create")]
[Route("v1/create/user")]
public sealed class CreateUserController(AppDbContext context) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ExecuteAsync([FromBody] CreateUserRequest createRequest, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        if (await context.Users.AnyAsync(x => x.Email == createRequest.Email, cancellationToken))
            return Conflict(new { message = "Email já está em uso, tente outro." });

        if (await context.Users.AnyAsync(x => x.Phone == createRequest.Phone, cancellationToken))
            return Conflict(new { message = "Telefone já está em uso, tente outro." });

        var user = new User(
            name: createRequest.Name,
            email: createRequest.Email,
            phone: createRequest.Phone,
            password: Hasher.GenerateHash(createRequest.Password)
        );

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return Created("", new { message = "Conta criada com sucesso." });
    }
}