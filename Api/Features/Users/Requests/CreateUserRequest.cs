using System.ComponentModel.DataAnnotations;

namespace Api.Features.Users.Requests;

public sealed record CreateUserRequest
{
    [Required(ErrorMessage = "O Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome deve ter entre 1 e 100 caracteres.")]
    public required string Name { get; init; }

    [Required(ErrorMessage = "O Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email é inválido.")]
    [StringLength(255, ErrorMessage = "O Email deve ter até 255 caracteres.")]
    public required string Email { get; init; }

    [Required(ErrorMessage = "O Telefone é obrigatório.")]
    [Phone(ErrorMessage = "O Telefone é inválido.")]
    [StringLength(15, ErrorMessage = "O Telefone deve ter até 15 caracteres.")]
    public required string Phone { get; init; }

    [Required(ErrorMessage = "A Senha é obrigatória.")]
    [StringLength(30, ErrorMessage = "A Senha deve ter até 30 caracteres.")]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}