using Api.Shared.Base;

namespace Api.Features.Users.Models;

public sealed class User : Entity
{
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }

    // Usado para instanciar novos usuários
    public User(string name, string email, string phone, string password) : base(name)
    {
        Email = email;
        Phone = phone;
        Password = password;
    }

    // Usado para instanciar usuários salvos no banco
    public User(Guid id, string name, DateTime created, string email, string phone, string password) : base(id, name, created)
    {
        Email = email;
        Phone = phone;
        Password = password;
    }
}