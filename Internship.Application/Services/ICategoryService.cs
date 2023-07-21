using Internship.Contracts.Dtos.CategoryDtos;
using Internship.Domain.Entities;

namespace Internship.Application.Services;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task<CategoryDto> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
    Task DeleteCategoryAsync(Guid id);
    Task<CategoryDto> GetCategoryByIdAsync(Guid id);
    Task<List<CategoryDto>> GetAllCategoriesAsync();
}