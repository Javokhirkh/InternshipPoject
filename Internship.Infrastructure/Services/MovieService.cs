using AutoMapper;
using Internship.Application.Common.Interfaces;
using Internship.Application.Exceptions.Movie;
using Internship.Application.Services;
using Internship.Contracts.Dtos.MovieDtos;
using Internship.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Internship.Infrastructor.Services;

public class MovieService : IMovieService
{
    private readonly ILogger<MovieService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovieService(ILogger<MovieService> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
    {
        var movie = _mapper.Map<Movie>(movieCreateDto);

        await _unitOfWork.MovieRepository.AddAsync(movie);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto> UpdateMovieAsync(MovieUpdateDto movieUpdateDto)
    {
        var movieEntity = await _unitOfWork.MovieRepository.GetByIdAsync(movieUpdateDto.Id);
        if (movieEntity == null)
            throw new MovieNotFoundException(movieUpdateDto.Id);

        movieEntity = _mapper.Map(movieUpdateDto, movieEntity);

        _unitOfWork.MovieRepository.Update(movieEntity);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<MovieDto>(movieEntity);
    }

    public async Task DeleteMovieAsync(Guid id)
    {
        var movieEntity = await _unitOfWork.MovieRepository.GetByIdAsync(id);

        if (movieEntity == null)
            throw new MovieNotFoundException(id);

        _unitOfWork.MovieRepository.Delete(movieEntity);

        await _unitOfWork.CommitAsync();
    }

    public async Task<MovieDto> GetMovieByIdAsync(Guid id)
    {
        var movieEntity = await _unitOfWork.MovieRepository.GetByIdAsync(id, trackChanges: false);

        if (movieEntity == null)
            throw new MovieNotFoundException(id);

        return _mapper.Map<MovieDto>(movieEntity);
    }

    public async Task<List<MovieDto>> GetAllMoviesAsync()
    {
        var movieEntities = await _unitOfWork.MovieRepository.GetAllAsync(trackChanges: false);

        return _mapper.Map<List<MovieDto>>(movieEntities);
    }
}