using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Persistence;

public class AppDbContext : IdentityDbContext<User>
{

    
    // TODO: move the token the database string to config file 
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<User> Users { get; set; }

}

