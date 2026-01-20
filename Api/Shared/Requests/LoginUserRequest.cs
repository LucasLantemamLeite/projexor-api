using System.ComponentModel.DataAnnotations;

namespace Api.Shared.Requests;

public record LoginUserRequest
{
    [Required(ErrorMessage = "O Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email é inválido.")]
    [StringLength(255, ErrorMessage = "O Email deve ter até 255 caracteres.")]
    public required string Email { get; init; }

    [Required(ErrorMessage = "A Senha é obrigatória.")]
    [StringLength(30, ErrorMessage = "A Senha deve ter até 30 caracteres.")]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}