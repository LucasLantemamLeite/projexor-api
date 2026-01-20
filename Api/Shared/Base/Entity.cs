namespace Api.Shared.Base;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime Created { get; protected set; }
    public bool Active { get; protected set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
        Active = true;
    }

    public Entity(Guid id, DateTime created, bool active)
    {
        Id = id;
        Created = created;
        Active = active;
    }
}