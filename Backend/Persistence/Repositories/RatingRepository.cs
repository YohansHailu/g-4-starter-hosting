using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepository;

namespace Persistence.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        private readonly AppDbContext _dbContext;

        public RatingRepository(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Rating>> GetAllRatingsForBlog(Guid blogId)
        {
            return await _dbContext.Ratings.Where(r => r.BlogId == blogId).ToListAsync();
        }

        
    }
}