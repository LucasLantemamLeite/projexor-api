using Api.Features.Projects.Enums;
using Api.Shared.Base;

namespace Api.Features.Projects.Models;

public sealed class Project : Entity
{
    public EStatus Status { get; private set; }
    public DateTime? Deadline { get; private set; }
    public Guid OwnerId { get; private set; }
    public bool IsPersonal { get; private set; }

    // Usado para instanciar novos Projetos
    public Project(string name, EStatus status, DateTime? deadline, Guid ownerId, bool isPersonal) : base(name)
    {
        Status = status;
        Deadline = deadline;
        OwnerId = ownerId;
        IsPersonal = isPersonal;
    }

    // Usado para instanciar Projetos salvos no banco
    public Project(Guid id, string name, DateTime created, EStatus status, DateTime? deadline, Guid ownerId, bool isPersonal) : base(id, name, created)
    {
        Status = status;
        Deadline = deadline;
        OwnerId = ownerId;
        IsPersonal = isPersonal;
    }
}