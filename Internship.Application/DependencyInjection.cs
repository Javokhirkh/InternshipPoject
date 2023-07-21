using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Internship.Contracts.Mappings;

namespace Internship.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}