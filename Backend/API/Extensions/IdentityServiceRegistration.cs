using Domain;
using Persistence;

namespace API.Extensions;

public static class IdentityServiceRegistration
{
    
        public static IServiceCollection  AddIdentityCoreService(this IServiceCollection services)
        {
                
            services.AddIdentityCore<User>(
                    (options =>
                                {
                                    options.Password.RequireNonAlphanumeric = false;
                                    options.User.RequireUniqueEmail = true;
                                })
                    )
                .AddEntityFrameworkStores<AppDbContext>();
            
            return services;
        }
}