using System.Security.Claims;
using Api.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Projects.Controllers;

[ApiController]
[Route("v1/get/project")]
[Tags("Get")]
[Authorize]
public sealed class GetAllProjectsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        if (!Guid.TryParse(idClaim, out var userId))
            return Unauthorized(new { message = "Id inválido." });

        var projects = await context.Projects.Where(x => x.OwnerId == userId).ToListAsync(cancellationToken);

        if (projects.Count == 0)
            return NotFound(new { message = "Nenhum projeto foi encontrado." });

        return Ok(new { message = $"Foram encontrados {projects.Count} projetos", projects });
    }
}