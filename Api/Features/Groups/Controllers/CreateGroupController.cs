using System.Security.Claims;
using Api.Data.Context;
using Api.Features.Groups.Models;
using Api.Features.Groups.Requests;
using Api.Features.UserGroups.Enums;
using Api.Features.UserGroups.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Groups.Controllers;

[ApiController]
[Tags("Create")]
[Route("v1/create/group")]
[Authorize]
public sealed class CreateGroupController(AppDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ExecuteAsync([FromBody] CreateGroupRequest createRequest, CancellationToken cancellationToken = default)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        if (!Guid.TryParse(idClaim, out var userId))
            return Unauthorized(new { message = "Identificador recusado." });

        var group = new Group(
            name: createRequest.Name
        );

        var relation = new UserGroup(
            userId: userId,
            groupId: group.Id,
            role: ERole.Owner
        );

        context.Groups.Add(group);
        context.UserGroups.Add(relation);

        await context.SaveChangesAsync(cancellationToken);

        return Created("", new { message = "Grupo criado com sucesso." });
    }
}