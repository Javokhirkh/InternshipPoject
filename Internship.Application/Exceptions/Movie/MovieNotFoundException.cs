namespace Internship.Application.Exceptions.Movie;

public class MovieNotFoundException : Exception
{
    public MovieNotFoundException(Guid movieId) :
        base($"Movie with id {movieId} was not found")
    {
    }

    public MovieNotFoundException(Guid movieId, Exception innerException) :
        base($"Movie with id {movieId} was not found", innerException)
    {
    }

    public MovieNotFoundException(string message) : base(message)
    {
    }

    public MovieNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}