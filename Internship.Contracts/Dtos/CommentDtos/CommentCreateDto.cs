using System.ComponentModel.DataAnnotations;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.CommentDtos;

public class CommentCreateDto : IMapFrom<Movie>
{
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    [Required] 
    public string Text { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }
}