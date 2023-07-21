namespace Internship.Application.Exceptions;

public class CategoryNotFoundException:Exception
{
    public CategoryNotFoundException(Guid movieId) :
        base($"Category with id {movieId} was not found")
    {
    }

    public CategoryNotFoundException(Guid movieId, Exception innerException) :
        base($"Category with id {movieId} was not found", innerException)
    {
    }
}