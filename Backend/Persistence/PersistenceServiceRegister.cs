using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Contracts;
using Persistence.Repositories;
using Persistence.Repositories.GenericRepository;

namespace Persistence;

public static class PersistenceServiceRegister
{
    
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
                // adding the database context to dependency injection
                services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("RenderPostgresConnectionString")));
                
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                
                services.AddScoped<IBlogRepository, BlogRepository>();
                services.AddScoped<IRatingRepository, RatingRepository>();
                services.AddScoped<ICommentRepository, CommentRepository>();
                services.AddScoped<IUserProfileRepository, UserProfileRepository>();

                return services;
        }
}