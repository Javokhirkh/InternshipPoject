using Internship.Domain.Entities;

namespace Internship.Application.Services;

public interface IMovieCategoryService
{
    Task <MovieCategory> GetMovieCategoryByIdAsync(Guid id);
    Task <MovieCategory> CreateMovieCategoryAsync(MovieCategory movieCategory);
    Task DeleteMovieCategoryAsync(Guid id);

}