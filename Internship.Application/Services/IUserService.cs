using Internship.Contracts.Dtos.UserDtos;

namespace Internship.Application.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);
    Task<UserDto> UpdateUserAsync(UserUpdateDto userUpdateDto);
    Task DeleteUserAsync(Guid id);
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<List<UserDto>> GetAllUsersAsync();
}