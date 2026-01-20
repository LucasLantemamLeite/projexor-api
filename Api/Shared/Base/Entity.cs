namespace Api.Shared.Base;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public DateTime Created { get; protected set; }
    public bool Active { get; protected set; }

    public Entity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Created = DateTime.UtcNow;
        Active = true;
    }

    public Entity(string name, Guid id, DateTime created, bool active)
    {
        Id = id;
        Name = name;
        Created = created;
        Active = active;
    }
}