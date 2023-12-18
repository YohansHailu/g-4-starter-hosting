using Application.Contracts;
using Application.DTOs.UserProfile;
using Application.Features.UserProfile.Requests.Command;
using AutoMapper;
using MediatR;

namespace Application.Features.UserProfile.Handlers.Command;

public class CreateUserProfileHandler : IRequestHandler<CreateUserProfileCommand, Domain.UserProfile>
{
    
    private IUserProfileRepository _repository;
    private readonly IMapper _mapper;
    
    public CreateUserProfileHandler(IUserProfileRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Domain.UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = _mapper.Map<Domain.UserProfile>(request.UserProfileDto);
        return _repository.Add(userProfile);
    }
}