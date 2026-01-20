namespace Api.Shared.Base;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public DateTime Created { get; protected set; }

    public Entity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Created = DateTime.UtcNow;
    }

    public Entity(Guid id, string name, DateTime created)
    {
        Id = id;
        Name = name;
        Created = created;
    }
}