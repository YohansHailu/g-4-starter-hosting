using Application.Contracts;
using Application.DTOs.UserProfile;
using Application.Features.UserProfile.Requests.Queries;
using MediatR;

namespace Application.Features.UserProfile.Handlers.Queries;

public class GetUserProfileRequestHandler: IRequestHandler<GetUserProfileRequest, Domain.UserProfile>
{

    private IUserProfileRepository _repository;
    public GetUserProfileRequestHandler(IUserProfileRepository repository)
    {
        _repository = repository;
    }

    public Task<Domain.UserProfile> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
    {
        return _repository.Get(request.Id);
    }
    
}