using Application.DTOs.Rating;
using Domain;
using MediatR;

namespace Application.Features.Ratings.Requests.Commands
{
    public class UpdateRatingCommand : IRequest<Rating>
    {
        public UpdateRatingDto UpdateRatingDto { get; set; }
        
    }
}