using Application.DTOs.Rating;
using MediatR;

namespace Application.Features.Ratings.Requests.Commands
{
    public class UpdateRatingCommand : IRequest<Unit>
    {
        public UpdateRatingDto UpdateRatingDto { get; set; }
        
    }
}