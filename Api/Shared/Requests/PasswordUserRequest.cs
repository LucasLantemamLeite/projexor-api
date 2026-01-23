using System.ComponentModel.DataAnnotations;

namespace Api.Shared.Requests;

public record PasswordUserRequest
{
    [Required(ErrorMessage = "A Senha é obrigatória.")]
    [StringLength(30, ErrorMessage = "A Senha deve ter até 30 caracteres.")]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}