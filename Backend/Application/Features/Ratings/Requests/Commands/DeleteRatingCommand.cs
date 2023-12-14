using MediatR;

namespace Application.Features.Ratings.Requests.Commands
{
    public class DeleteRatingCommand : IRequest
    {
        public int Id { get; set; }
    }
}