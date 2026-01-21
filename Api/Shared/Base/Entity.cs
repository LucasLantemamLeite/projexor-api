namespace Api.Shared.Base;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime Created { get; protected set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
    }

    public Entity(Guid id, DateTime created)
    {
        Id = id;
        Created = created;
    }
}