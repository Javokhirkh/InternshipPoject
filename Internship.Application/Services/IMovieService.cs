using Internship.Contracts.Dtos.MovieDtos;

namespace Internship.Application.Services;

public interface IMovieService
{
    Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto);
    Task<MovieDto> UpdateMovieAsync(MovieUpdateDto movieUpdateDto);
    Task DeleteMovieAsync(Guid id);
    Task<MovieDto> GetMovieByIdAsync(Guid id);
    Task<List<MovieDto>> GetAllMoviesAsync();
    
}