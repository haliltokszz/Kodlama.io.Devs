namespace Core.Persistence.Repositories;

public class Entity
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; }
    public bool isDeleted { get; set; } = false;

    public Entity()
    {
        CreatedDate = DateTime.UtcNow;
    }
    
    public Entity(Guid id) : this()
    {
        Id = id;
    }
}