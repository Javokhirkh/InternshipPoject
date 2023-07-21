namespace Internship.Application.Exceptions.User;

public class UserNotFoundException :Exception
{
    public UserNotFoundException(Guid movieId) :
        base($"User with id {movieId} was not found")
    {
    }

    public UserNotFoundException(Guid movieId, Exception innerException) :
        base($"User with id {movieId} was not found", innerException)
    {
    }
}