using Application.Contracts;
using Application.DTOs.UserProfile;
using Application.Features.UserProfile.Requests.Queries;
using MediatR;

namespace Application.Features.UserProfile.Handlers.Queries;

public class DeleteUserProfileHandler: IRequestHandler<DeleteUserProfileCommand, Domain.UserProfile>
{

    private IUserProfileRepository _repository;
    public DeleteUserProfileHandler(IUserProfileRepository repository)
    {
        _repository = repository;
    }

    public Task<Domain.UserProfile> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        Console.Write("am here in delte handler with Id " + request.Id );
        return _repository.DeleteById(request.Id);
    }
    
}
