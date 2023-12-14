using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions;

public static class AuthenticationHandlerServiceRegistration
{
        public static IServiceCollection  AddAuthenticationHandlerService(this IServiceCollection services, IConfiguration config)
        {
            
            
            var tokenKey = config["tokenKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            services.AddAuthentication(op =>
            {
                op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = key,
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
                   
                   
            });
            
            return services;
            
        }
}