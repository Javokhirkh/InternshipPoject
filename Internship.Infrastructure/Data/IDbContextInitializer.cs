namespace Internship.Infrastructor.Data;

public interface IDbContextInitializer
{
    Task InitialiseAsync();
}