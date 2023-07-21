namespace Internship.Application.Exceptions.Comment;

public class CommentNotFoundException: Exception
{
    public CommentNotFoundException(Guid movieId) :
        base($"Comment with id {movieId} was not found")
    {
    }

    public CommentNotFoundException(Guid movieId, Exception innerException) :
        base($"Comment with id {movieId} was not found", innerException)
    {
    }
}