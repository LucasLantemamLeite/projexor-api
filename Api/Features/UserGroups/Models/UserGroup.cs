using Api.Features.Groups.Models;
using Api.Features.UserGroups.Enums;
using Api.Features.Users.Models;
using Api.Shared.Base;

namespace Api.Features.UserGroups.Models;

public sealed class UserGroup : Entity
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid GroupId { get; private set; }
    public Group? Group { get; private set; }
    public ERole Role { get; private set; }

    public UserGroup(Guid userId, Guid groupId, ERole role)
    {
        UserId = userId;
        GroupId = groupId;
        Role = role;
    }

    public UserGroup(Guid id, DateTime created, Guid userId, Guid groupId, ERole role) : base(id, created)
    {
        UserId = userId;
        GroupId = groupId;
        Role = role;
    }
}