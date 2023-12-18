using Domain;

namespace Application.Contracts;

public interface IUserProfileRepository : IGenericRepository<UserProfile>
{

    public Task<UserProfile> GetByUserId(Guid userId);
    public Task<UserProfile> DeleteById(Guid userId);
}