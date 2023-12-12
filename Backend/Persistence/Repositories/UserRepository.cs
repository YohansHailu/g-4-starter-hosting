using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepository;
using Domain;
namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(AppDbContext dbContext):base(dbContext)
    {
    }
}