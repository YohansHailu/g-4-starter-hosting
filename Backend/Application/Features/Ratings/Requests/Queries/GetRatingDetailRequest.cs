using Application.DTOs.Rating;
using Domain;
using MediatR;

namespace Application.Features.Ratings.Requests.Queries
{
    public class GetRatingDetailRequest : IRequest<Rating>
    {
        public Guid Id { get; set; }
    }
}