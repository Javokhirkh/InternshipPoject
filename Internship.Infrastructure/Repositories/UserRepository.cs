using Internship.Application.Repositories;
using Internship.Domain.Entities;
using Internship.Infrastructor.Common;
using Internship.Infrastructor.Data;

namespace Internship.Infrastructor.Repositories;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}