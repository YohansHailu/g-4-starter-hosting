using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepository;

namespace Persistence.Repositories
{
    public class RatingRepository : GenericRepository<Rating>
    {
        private readonly AppDbContext _dbContext;

        public async Task<IReadOnlyList<Rating>> GetAll(Guid Id)
        {
            return await _dbContext.Set<Rating>().ToListAsync();
        }
        public RatingRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }
        
    }
}