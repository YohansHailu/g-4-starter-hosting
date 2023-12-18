using Application.DTOs.UserProfile;
using MediatR;

namespace Application.Features.UserProfile.Requests.Command;

public class UpdateUserProfileCommand : IRequest<Domain.UserProfile>
{
    public UserProfileDto UserProfileDto{ set; get; }
}