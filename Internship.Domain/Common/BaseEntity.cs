namespace Internship.Domain.Common;

public abstract class BaseEntity<TKey> : IHaveIdProp<TKey>
{
    public TKey Id { get; set; }
}