using System.ComponentModel.DataAnnotations;
using Api.Shared.Requests;

namespace Api.Features.Users.Requests;

public sealed record LoginUserRequest : PasswordUserRequest
{
    [Required(ErrorMessage = "O Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email é inválido.")]
    [StringLength(255, ErrorMessage = "O Email deve ter até 255 caracteres.")]
    public required string Email { get; init; }
}