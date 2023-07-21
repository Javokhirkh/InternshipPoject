using Internship.Application.Repositories;
using Internship.Domain.Entities;
using Internship.Infrastructor.Common;
using Internship.Infrastructor.Data;

namespace Internship.Infrastructor.Repositories;

public class CommentRepository : RepositoryBase<Comment, Guid>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    

    public Task<Comment> GetAllUserCommentsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}