using Api.Features.Projects.Models;
using Api.Features.UserGroups.Models;
using Api.Shared.Base;

namespace Api.Features.Groups.Models;

public sealed class Group : Entity
{
    public string Name { get; private set; }
    public ICollection<Project> Projects { get; private set; } = [];
    public ICollection<UserGroup> UserGroups { get; private set; } = [];

    public Group(string name)
    {
        Name = name;
    }

    public Group(Guid id, string name, DateTime created) : base(id, created)
    {
        Name = name;
    }
}

