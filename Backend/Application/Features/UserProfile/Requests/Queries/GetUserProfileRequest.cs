using MediatR;

namespace Application.Features.UserProfile.Requests.Queries;

public class GetUserProfileRequest : IRequest<Domain.UserProfile>
{
       public Guid Id{get; set;}
}