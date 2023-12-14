using API.Extensions;
using Persistence;
using Microsoft.AspNetCore.Identity;
using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// its using extension method
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AddAuthenticationTokenService();
builder.Services.AddAuthenticationHandlerService(builder.Configuration);

// adding UserManager Service
builder.Services.AddIdentityCoreService();


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
