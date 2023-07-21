using System.ComponentModel.DataAnnotations;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.MovieDtos;

public class MovieCreateDto : IMapFrom<Movie>
{
    [Required] public string MovieName { get; set; }
    public string Description { get; set; }
    [Required] public string ImageUrl { get; set; }
}