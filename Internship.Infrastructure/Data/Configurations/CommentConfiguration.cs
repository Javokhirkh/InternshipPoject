using Internship.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship.Infrastructor.Data.Configurations;

public class CommentConfiguration: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(x=>x.Movie)
            .WithMany(x=>x.Comments)
            .HasForeignKey(x=>x.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x=>x.User)
            .WithMany(x=>x.Comments)
            .HasForeignKey(x=>x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}