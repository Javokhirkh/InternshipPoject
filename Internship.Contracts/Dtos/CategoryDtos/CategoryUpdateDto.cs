using System.ComponentModel.DataAnnotations;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.CategoryDtos;

public class CategoryUpdateDto:IMapFrom<Category>
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}