using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.UserDtos;

public class UserUpdateDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}