using API.Services;
namespace API.Extensions;

public static  class AuthenticationTokenServiceRegistration
{

        public static IServiceCollection  AddAuthenticationTokenService(this IServiceCollection services)
        {
                services.AddScoped<AuthenticationTokenService>();
                return services;
        }
}