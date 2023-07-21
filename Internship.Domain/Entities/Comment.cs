using System.ComponentModel.DataAnnotations;
using Internship.Domain.Common;

namespace Internship.Domain.Entities;

public class Comment : BaseEntity<Guid>
{
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    
    [Required]
    public string Text { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }
}