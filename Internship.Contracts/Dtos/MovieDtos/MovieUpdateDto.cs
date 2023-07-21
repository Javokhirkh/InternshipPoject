using System.ComponentModel.DataAnnotations;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.MovieDtos;

public class MovieUpdateDto : IMapFrom<Movie>
{
    public Guid Id { get; set; }
    [Required]
    public string MovieName { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double AverageRating { get; set; }
}