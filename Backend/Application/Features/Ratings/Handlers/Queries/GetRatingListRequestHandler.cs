using Application.Contracts;
using Application.DTOs.Rating;
using Application.Features.Ratings.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Ratings.Handlers.Queries
{
    public class GetRatingListRequestHandler : IRequestHandler<GetRatingListRequest, List<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetRatingListRequestHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<List<RatingDto>> Handle(GetRatingListRequest request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.GetAll(request.Id);

            return _mapper.Map<List<RatingDto>>(rating);
        }
    }
}