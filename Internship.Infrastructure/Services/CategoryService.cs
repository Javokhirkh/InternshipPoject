using AutoMapper;
using Internship.Application.Common.Interfaces;
using Internship.Application.Exceptions;
using Internship.Application.Services;
using Internship.Contracts.Dtos.CategoryDtos;
using Internship.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Internship.Infrastructor.Services;

public class CategoryService : ICategoryService
{
    private readonly ILogger<User> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CategoryService(ILogger<User> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        var category = _mapper.Map<Category>(categoryCreateDto);
        
        await _unitOfWork.CategoryRepository.AddAsync(category);

        await _unitOfWork.CommitAsync();
        
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
    {
        var categoryEntity = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryUpdateDto.Id);

        if (categoryEntity == null)
        {
            throw new CategoryNotFoundException(categoryUpdateDto.Id);
        }
        categoryEntity =_mapper.Map(categoryUpdateDto, categoryEntity);
        
        _unitOfWork.CategoryRepository.Update(categoryEntity);
        
        await _unitOfWork.CommitAsync();
        
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var categoryEntity = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        
        if (categoryEntity == null)
        {
            throw new CategoryNotFoundException(id);
        }
        
        _unitOfWork.CategoryRepository.Delete(categoryEntity);
        
        await _unitOfWork.CommitAsync();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
    {
        var categoryEntity=await _unitOfWork.CategoryRepository.GetByIdAsync(id);

        if (categoryEntity == null)
        {
            throw new CategoryNotFoundException(id);
        }
        
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categoryEntities = await _unitOfWork.CategoryRepository.GetAllAsync();

        return _mapper.Map<List<CategoryDto>>(categoryEntities);
    }
}