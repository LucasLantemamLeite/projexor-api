using Api.Features.Projects.Enums;
using Api.Features.Users.Models;
using Api.Shared.Base;

namespace Api.Features.Projects.Models;

public sealed class Project : Entity
{
    public string Name { get; private set; }
    public EStatus Status { get; private set; }
    public DateTime? Deadline { get; private set; }
    public Guid OwnerId { get; private set; }
    public bool IsPersonal { get; private set; }
    public User? User { get; private set; }

    // Usado para instanciar novos Projetos
    public Project(string name, EStatus status, DateTime? deadline, Guid ownerId, bool isPersonal)
    {
        Name = name;
        Status = status;
        Deadline = deadline;
        OwnerId = ownerId;
        IsPersonal = isPersonal;
    }

    // Usado para instanciar Projetos salvos no banco
    public Project(Guid id, string name, DateTime created, EStatus status, DateTime? deadline, Guid ownerId, bool isPersonal) : base(id, created)
    {
        Name = name;
        Status = status;
        Deadline = deadline;
        OwnerId = ownerId;
        IsPersonal = isPersonal;
    }
}