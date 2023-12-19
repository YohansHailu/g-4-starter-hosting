using System.Security.Claims;

namespace API.Services;

public class AuthenticatedUserService : IAuthenticatedUserService
{

    public Guid GetUserId(ClaimsPrincipal user)
    {
        return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}