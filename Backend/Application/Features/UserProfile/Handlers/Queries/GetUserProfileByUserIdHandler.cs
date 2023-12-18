using Application.Contracts;
using Application.Features.UserProfile.Requests.Queries;
using MediatR;

namespace Application.Features.UserProfile.Handlers.Queries;

public class GetUserProfileByUserIdHandler : IRequestHandler<GetUserProfileByUserIdRequest, Domain.UserProfile>
{

    private readonly IUserProfileRepository _repository;

    public GetUserProfileByUserIdHandler(IUserProfileRepository repository)
    {
        _repository = repository;
    }

    public Task<Domain.UserProfile> Handle(GetUserProfileByUserIdRequest request, CancellationToken cancellationToken)
    {
        return _repository.GetByUserId(request.UserId);
    }

}