using MediatR;

namespace Application.Features.Ratings.Requests.Commands
{
    public class DeleteRatingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}