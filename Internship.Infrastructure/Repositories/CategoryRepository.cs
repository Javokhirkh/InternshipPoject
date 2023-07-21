using Internship.Application.Repositories;
using Internship.Domain.Entities;
using Internship.Infrastructor.Common;
using Internship.Infrastructor.Data;

namespace Internship.Infrastructor.Repositories;

public class CategoryRepository : RepositoryBase<Category, Guid>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}