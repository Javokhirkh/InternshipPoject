namespace Internship.Domain.Common;

public interface IHaveIdProp<Tkey>
{
    public Tkey Id { get; set; }
}
