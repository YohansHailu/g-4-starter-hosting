using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public static class PersistenceServiceRegister
{
    
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
                // adding the database context to dependency injection
                services.AddDbContext<AppDbContext>();
                return services;
        }
}