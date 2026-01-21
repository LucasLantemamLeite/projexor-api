using Api.Features.Projects.Models;
using Api.Shared.Base;

namespace Api.Features.Users.Models;

public sealed class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }
    public ICollection<Project> Projects { get; private set; } = [];

    // Usado para instanciar novos usuários
    public User(string name, string email, string phone, string password)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Password = password;
    }

    // Usado para instanciar usuários salvos no banco
    public User(Guid id, string name, DateTime created, string email, string phone, string password) : base(id, created)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Password = password;
    }
}