using Internship.Application.Repositories;
using Internship.Domain.Entities;
using Internship.Infrastructor.Common;
using Internship.Infrastructor.Data;

namespace Internship.Infrastructor.Repositories;

public class MovieRepository : RepositoryBase<Movie, Guid>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    {
    }
}