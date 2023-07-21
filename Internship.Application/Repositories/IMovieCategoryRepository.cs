using Internship.Application.Common.Interfaces;
using Internship.Domain.Entities;

namespace Internship.Application.Repositories;

public interface IMovieCategoryRepository:IRepositoryBase<MovieCategory,Guid>
{
}