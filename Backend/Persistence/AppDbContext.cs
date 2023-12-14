using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Persistence;

public class AppDbContext : IdentityDbContext<User>
{

    
    // TODO: move the token the database string to config file 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: move the connection string to config file 
        //PGPASSWORD=sSopxoPBU8vuJZy6vzHwB20n1fsUEq5N psql -h dpg-clt9j921hbls73ebs8l0-a.frankfurt-postgres.render.com -U yohansh blogdb_ca1y
        optionsBuilder.UseNpgsql("Host=dpg-clt9j921hbls73ebs8l0-a.frankfurt-postgres.render.com;" +
                                 "Port=5432;" +
                                 "Database=blogdb_ca1y;" +
                                 "Username=yohansh ;" +
                                 "Password=sSopxoPBU8vuJZy6vzHwB20n1fsUEq5N");
        
        
    }

    public DbSet<User> Users { get; set; }

}

