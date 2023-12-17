namespace Domain.Common;

public abstract class BaseDomainEntity
{
    public Guid ID { get; set; }
     public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}