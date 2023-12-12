using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Persistence;

public class AppDbContext : IdentityDbContext<User>
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mainDb.db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>() //Use your application user class here
               .ToTable("AspNetUsers"); //Set the table name here
    }

    public DbSet<User> Users { get; set; }

}

