using AutoMapper;
using Internship.Application.Common.Interfaces;
using Internship.Application.Exceptions.MovieCategory;
using Internship.Application.Services;
using Internship.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Internship.Infrastructor.Services;

public class MovieCategoryService:IMovieCategoryService
{
    
    private readonly ILogger<CommentService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovieCategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CommentService> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<MovieCategory> GetMovieCategoryByIdAsync(Guid id)
    {
        var movieCategory = await _unitOfWork.MovieCategoryRepository.GetByIdAsync(id);
        if (movieCategory == null)
            throw new MovieCategoryNotFoundException(id);
        
        return movieCategory;
    }
    
    

    public async Task<MovieCategory> CreateMovieCategoryAsync(MovieCategory movieCategory)
    {
        await _unitOfWork.MovieCategoryRepository.AddAsync(movieCategory);
        await _unitOfWork.CommitAsync();
        return movieCategory;
    }

    public async Task DeleteMovieCategoryAsync(Guid id)
    {
        var movieCategory = _unitOfWork.MovieCategoryRepository.GetByIdAsync(id);
        if (movieCategory == null)
            throw new MovieCategoryNotFoundException(id);
        
         _unitOfWork.MovieCategoryRepository.Delete(movieCategory.Result);
         await _unitOfWork.CommitAsync();
    }
}