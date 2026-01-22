using System.ComponentModel.DataAnnotations;

namespace Api.Features.Groups.Requests;

public sealed record CreateGroupRequest
{
    [Required(ErrorMessage = "O Nome é obrigatório.")]
    [StringLength(30, ErrorMessage = "O Nome deve ter entre 1 e 30 caracteres.")]
    public required string Name { get; init; }
}