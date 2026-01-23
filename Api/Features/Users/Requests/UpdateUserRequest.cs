using System.ComponentModel.DataAnnotations;
using Api.Shared.Requests;

namespace Api.Features.Users.Requests;

public sealed record UpdateUserRequest : PasswordUserRequest
{
    [MaxLength(100, ErrorMessage = "O Nome deve ter entre 1 e 100 caracteres.")]
    public string? Name { get; init; }

    [EmailAddress(ErrorMessage = "O Email é inválido.")]
    [MaxLength(255, ErrorMessage = "O Email deve ter até 255 caracteres.")]
    public string? Email { get; init; }

    [Phone(ErrorMessage = "O Telefone é inválido.")]
    [MaxLength(15, ErrorMessage = "O Telefone deve ter até 15 caracteres.")]
    public string? Phone { get; init; }

    [MaxLength(30, ErrorMessage = "A Senha deve ter até 30 caracteres.")]
    [DataType(DataType.Password)]
    public string? NewPassword { get; init; }
}