using Application.DTOs.Rating;
using MediatR;

namespace Application.Features.Ratings.Requests.Commands
{
    public class CreateRatingCommand : IRequest<Unit>
    {
        public RatingDto CreateRatingDto { get; set; }
    }
}