namespace Innoplatforma.Server.Domain.Commons;

public abstract class Auditable <TKey>
{
    public TKey Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set;}
}
