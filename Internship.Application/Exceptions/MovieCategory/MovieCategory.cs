namespace Internship.Application.Exceptions.MovieCategory;

public class MovieCategoryNotFoundException :Exception
{
    public MovieCategoryNotFoundException(Guid movieId) :
        base($" Movie Categoty with id {movieId} was not found")
    {
    }

    public MovieCategoryNotFoundException(Guid movieId, Exception innerException) :
        base($"Movie Category with id {movieId} was not found", innerException)
    {
    }
}