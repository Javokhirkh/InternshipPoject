using System.ComponentModel.DataAnnotations;
using Internship.Domain.Common;

namespace Internship.Domain.Entities;

public class Category: BaseEntity<Guid>
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }
    
    public List<MovieCategory> MovieCategories { get; set; }
}