using Internship.Application.Repositories;

namespace Internship.Application.Common.Interfaces;

public interface IUnitOfWork
{
    ICommentRepository CommentRepository { get; }
    IMovieRepository ReviewRepository { get; }
    IUserRepository UserRepository { get; }
    IMovieRepository MovieRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IMovieCategoryRepository MovieCategoryRepository { get; }


    int Commit();
    Task<int> CommitAsync();
    void Rollback();
    Task RollbackAsync();
    
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
    
    void Dispose();
}