using System.Security.Claims;

namespace API.Services;

public interface IAuthenticatedUserService
{
    Guid GetUserId(ClaimsPrincipal user);
}