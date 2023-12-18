using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Persistence;

public class AppDbContext : IdentityDbContext<User>
{

    
    // TODO: move the token the database string to config file 
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }

 


    
    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

}

