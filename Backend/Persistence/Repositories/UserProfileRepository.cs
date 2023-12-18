using Persistence.Repositories.GenericRepository;
using Application.Contracts;
using Application.Exceptions;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
{
    private AppDbContext _dbContext;

    public UserProfileRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserProfile> GetByUserId(Guid userId)
    {
        var userProfile = await _dbContext.UserProfiles
            .FirstOrDefaultAsync(u => u.UserId == userId);
        if (userProfile == null)
        {
            throw new NotFoundException(nameof(Domain.UserProfile), userId);
        }

        return userProfile;

    }

    public async Task<UserProfile> DeleteById(Guid id)
    {
        var userProfileToDelete = _dbContext.UserProfiles
            .FirstOrDefault(u => u.Id == id);

        if (userProfileToDelete == null)
        {
            throw new NotFoundException(nameof(Domain.UserProfile), id);
        }

        _dbContext.UserProfiles.Remove(userProfileToDelete);
        await _dbContext.SaveChangesAsync();

        return userProfileToDelete;

    }
}