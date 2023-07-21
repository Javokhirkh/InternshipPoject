using Internship.Contracts.Dtos.CommentDtos;
using Internship.Domain.Entities;

namespace Internship.Application.Services;

public interface ICommentService
{
    Task<CommentDto> CreateCommentAsync(CommentCreateDto commentCreateDto);
    Task<CommentDto> GetCommentByIdAsync(Guid id);
    Task<CommentDto> UpdateCommentAsync(CommentUpdateDto comment);
    Task DeleteCommentAsync(Guid id);

    Task<List<CommentDto>> GetAllCommentsAsync();
}