using Internship.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Internship.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<MovieCategory> MovieCategories { get; set; }
}