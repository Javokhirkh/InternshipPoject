using System.ComponentModel.DataAnnotations;
using Internship.Domain.Common;

namespace Internship.Domain.Entities;

public class Movie : BaseEntity<Guid>
{
    [Required] 
    public string MovieName { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public double AverageRating { get; set; }

    public List<Comment> Comments { get; set; }
    public List<MovieCategory> MovieCategories { get; set; }
}