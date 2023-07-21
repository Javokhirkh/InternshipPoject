using Internship.Contracts.Mappings;
using Internship.Domain.Entities;

namespace Internship.Contracts.Dtos.CommentDtos;

public class CommentDto : IMapFrom<Comment>
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
}