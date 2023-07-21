using Internship.Application.Common.Interfaces;
using Internship.Application.Repositories;
using Internship.Infrastructor.Data;
using Internship.Infrastructor.Repositories;

namespace Internship.Infrastructor;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private ICommentRepository _commentRepository;
    private IMovieRepository _reviewRepository;
    private IUserRepository _userRepository;
    private IMovieRepository _movieRepository;
    private ICategoryRepository _categoryRepository;
    private IMovieCategoryRepository _movieCategoryRepository;

    public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_context);
    public IMovieRepository ReviewRepository => _reviewRepository ??= new MovieRepository(_context);
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
    public IMovieCategoryRepository MovieCategoryRepository => _movieCategoryRepository ??= new MovieCategoryRepository(_context);

    public int Commit()
    {
        return _context.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Rollback()
    {
        _context.Database.CurrentTransaction?.Rollback();
    }

    public async Task RollbackAsync()
    {
        if (_context.Database.CurrentTransaction != null)
            await _context.Database.CurrentTransaction.RollbackAsync();
    }

    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _context.Database.CurrentTransaction?.Commit();
    }

    public void RollbackTransaction()
    {
        _context.Database.CurrentTransaction?.Rollback();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}