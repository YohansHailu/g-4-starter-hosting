using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepository;
using Domain;
using Application.Contracts;
namespace Persistence.Repositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext dbContext):base(dbContext)
    {
    }
}