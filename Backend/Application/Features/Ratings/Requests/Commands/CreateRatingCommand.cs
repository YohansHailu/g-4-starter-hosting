using Application.DTOs.Rating;
using Domain;
using MediatR;

namespace Application.Features.Ratings.Requests.Commands
{
    public class CreateRatingCommand : IRequest<Rating>
    {
        public RatingDto CreateRatingDto { get; set; }
    }
}