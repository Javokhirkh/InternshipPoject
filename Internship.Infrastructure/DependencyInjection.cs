using Internship.Application.Common.Interfaces;
using Internship.Application.Services;
using Internship.Infrastructor.Data;
using Internship.Infrastructor.Helpers;
using Internship.Infrastructor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internship.Infrastructor;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("ApplicationDbContext"));
            opt.EnableSensitiveDataLogging();
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IDbContextInitializer, ApplicationDbContextInitializer>();

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IMovieCategoryService, MovieCategoryService>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<ICategoryService,CategoryService>();
        
        return services;
    }
    
}