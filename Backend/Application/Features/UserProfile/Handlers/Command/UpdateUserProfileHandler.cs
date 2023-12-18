using Application.Contracts;
using Application.Features.UserProfile.Requests.Command;
using AutoMapper;
using MediatR;

namespace Application.Features.UserProfile.Handlers.Command;

public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, Domain.UserProfile>
{
    
    private IUserProfileRepository _repository;
    private readonly IMapper _mapper;
    
    public UpdateUserProfileHandler(IUserProfileRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Domain.UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = _mapper.Map<Domain.UserProfile>(request.UserProfileDto);
        return _repository.Update(userProfile);
    }
}
