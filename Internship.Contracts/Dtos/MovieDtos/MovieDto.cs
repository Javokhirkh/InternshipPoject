using Internship.Contracts.Dtos.CommentDtos;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.MovieDtos;

public class MovieDto:IMapFrom<Movie>
{
    public string MovieName { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double AverageRating { get; set; }
    public List<CommentDto> Comments { get; set; }
    
    
}