using Application.Contracts;
using Application.DTOs.Rating;
using Application.Features.Ratings.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Ratings.Handlers.Queries
{
    public class GetRatingDetailRequestHandler : IRequestHandler<GetRatingDetailRequest, RatingDto>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetRatingDetailRequestHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<RatingDto> Handle(GetRatingDetailRequest request, CancellationToken cancellationToken)
        {
             var rating = await _ratingRepository.Get(request.Id);

            return _mapper.Map<RatingDto>(rating);
        }
        
    }
    
}