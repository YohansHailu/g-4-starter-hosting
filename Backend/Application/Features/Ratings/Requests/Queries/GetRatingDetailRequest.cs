using Application.DTOs.Rating;
using MediatR;

namespace Application.Features.Ratings.Requests.Queries
{
    public class GetRatingDetailRequest : IRequest<RatingDto>
    {
        public int Id { get; set; }
    }
}