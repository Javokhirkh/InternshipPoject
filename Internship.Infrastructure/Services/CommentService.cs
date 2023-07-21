using AutoMapper;
using Internship.Application.Common.Interfaces;
using Internship.Application.Exceptions.Comment;
using Internship.Application.Services;
using Internship.Contracts.Dtos.CommentDtos;
using Internship.Domain.Entities;
using Microsoft.Extensions.Logging;
using Npgsql.Replication;

namespace Internship.Infrastructor.Services;

public class CommentService : ICommentService
{
    private readonly ILogger<CommentService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CommentService> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<CommentDto> CreateCommentAsync(CommentCreateDto commentCreateDto)
    {
        var comment = _mapper.Map<Comment>(commentCreateDto);

        await _unitOfWork.CommentRepository.AddAsync(comment);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<CommentDto>(comment);
    }

    public async Task<CommentDto> GetCommentByIdAsync(Guid id)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
        if (comment == null)
            throw new CommentNotFoundException(id);
        return _mapper.Map<CommentDto>(comment);
    }

    public async Task<CommentDto> UpdateCommentAsync(CommentUpdateDto comment)
    {
        var commentEntity = await _unitOfWork.CommentRepository.GetByIdAsync(comment.Id);
        if (commentEntity == null)
            throw new CommentNotFoundException(comment.Id);
        commentEntity = _mapper.Map(comment, commentEntity);

        _unitOfWork.CommentRepository.Update(commentEntity);
        
        await _unitOfWork.CommitAsync();
        
        return _mapper.Map<CommentDto>(commentEntity);
    }

    public async Task DeleteCommentAsync(Guid id)
    {
        var commentEntity = await _unitOfWork.CommentRepository.GetByIdAsync(id);
        
        if (commentEntity == null)
            throw new CommentNotFoundException(id);
        
        _unitOfWork.CommentRepository.Delete(commentEntity);
        
        await _unitOfWork.CommitAsync();

    }

    public Task<List<CommentDto>> GetAllCommentsAsync()
    {
        var comments = _unitOfWork.CommentRepository.GetAllAsync();
        return _mapper.Map<Task<List<CommentDto>>>(comments);
    }
}