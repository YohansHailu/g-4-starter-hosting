using MediatR;

namespace Application.Features.UserProfile.Requests.Queries;

public class GetUserProfileByUserIdRequest : IRequest<Domain.UserProfile>
{
       public Guid UserId{get; set;}
}
