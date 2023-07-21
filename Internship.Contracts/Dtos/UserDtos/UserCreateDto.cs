using System.ComponentModel.DataAnnotations;
using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.UserDtos;

public class UserCreateDto:IMapFrom<User>
{

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    [Required] [EmailAddress] 
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    
}