using Internship.Application.Repositories;
using Internship.Domain.Entities;
using Internship.Infrastructor.Common;
using Internship.Infrastructor.Data;

namespace Internship.Infrastructor.Repositories;

public class MovieCategoryRepository : RepositoryBase<MovieCategory, Guid>, IMovieCategoryRepository
{
    public MovieCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}