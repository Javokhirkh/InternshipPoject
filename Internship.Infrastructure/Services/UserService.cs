using AutoMapper;
using Internship.Application.Common.Interfaces;
using Internship.Application.Exceptions.User;
using Internship.Application.Services;
using Internship.Contracts.Dtos.UserDtos;
using Internship.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Internship.Infrastructor.Services;

public class UserService: IUserService
{
    private readonly ILogger<User> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UserService(ILogger<User> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> UpdateUserAsync(UserUpdateDto userUpdateDto)
    {
        var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(userUpdateDto.Id);
        if (userEntity == null)
            throw new UserNotFoundException(userUpdateDto.Id);
        
        userEntity= _mapper.Map(userUpdateDto, userEntity);
        
        _unitOfWork.UserRepository.Update(userEntity);
        
        await _unitOfWork.CommitAsync();
        
        return _mapper.Map<UserDto>(userEntity);
    }

    public  async Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto)
    {
        var user = _mapper.Map<User>(userCreateDto);

       await _unitOfWork.UserRepository.AddAsync(user);
        
       await _unitOfWork.CommitAsync();

       return _mapper.Map<UserDto>(user);
    }
    

    public  async Task DeleteUserAsync(Guid id)
    {
        var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(id);
        if (userEntity == null)
        {
            throw new UserNotFoundException(id);
        }
        _unitOfWork.UserRepository.Delete(userEntity);

        await _unitOfWork.CommitAsync();
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
        if (user == null)
        {
            throw new UserNotFoundException(id);
        }
        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();
        return _mapper.Map<List<UserDto>>(users);
    }
}