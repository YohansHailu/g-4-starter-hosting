using Domain;

namespace Application.Contracts
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<IReadOnlyList<Rating>> GetAllRatingsForBlog(Guid Id);
    }
}