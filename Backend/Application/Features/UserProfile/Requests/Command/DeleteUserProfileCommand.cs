using MediatR;

namespace Application.Features.UserProfile.Requests.Queries;

public class DeleteUserProfileCommand: IRequest<Domain.UserProfile>
{
       public Guid Id{get; set;}
}
