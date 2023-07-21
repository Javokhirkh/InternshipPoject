using Internship.Domain.Common;

namespace Internship.Domain.Entities;

public class MovieCategory:BaseEntity<Guid>
{
    public Guid MovieId { get; set; }
    public Guid CategoryId { get; set; }
    
    public Movie Movie { get; set; }
    public Category Category { get; set; }
}