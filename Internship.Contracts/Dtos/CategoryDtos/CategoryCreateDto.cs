using System.ComponentModel.DataAnnotations;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.CategoryDtos;

public class CategoryCreateDto : IMapFrom<Category>
{
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
}