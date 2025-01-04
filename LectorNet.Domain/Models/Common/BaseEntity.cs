namespace LectorNet.Domain.Models.Common;

public class BaseEntity
{
    public Guid Id { get; init ; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}