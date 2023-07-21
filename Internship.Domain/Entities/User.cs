using System.ComponentModel.DataAnnotations;
using Internship.Domain.Common;

namespace Internship.Domain.Entities;

public class User : BaseEntity<Guid>
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public string Country { get; set; }

    public List<Comment> Comments { get; set; }
}