using Application.DTOs.Rating;
using MediatR;

namespace Application.Features.Ratings.Requests.Queries
{
    public class GetRatingListRequest : IRequest<List<RatingDto>>
    {
        public Guid Id {get; set;}
    }
}