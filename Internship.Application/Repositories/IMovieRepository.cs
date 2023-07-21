using Internship.Application.Common.Interfaces;
using Internship.Domain.Entities;

namespace Internship.Application.Repositories;

public interface IMovieRepository : IRepositoryBase<Movie, Guid>
{
}