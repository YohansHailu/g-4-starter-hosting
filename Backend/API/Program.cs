using API.Extensions;
using API.Services;
using Persistence;
using Microsoft.AspNetCore.Identity;
using Domain;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// its using extension method
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AddAuthenticationTokenService();
builder.Services.AddAuthenticationHandlerService(builder.Configuration);

// adding UserManager Service
builder.Services.AddIdentityCoreService();

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
