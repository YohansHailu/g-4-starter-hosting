using Application.Contracts;
using Application.Features.Ratings.Requests.Commands;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Ratings.Handlers.Commands
{
    public class UpdateRatingRequestHandler : IRequestHandler<UpdateRatingCommand, Rating>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public UpdateRatingRequestHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<Rating> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
    
            var rating = await _ratingRepository.Get(request.UpdateRatingDto.Id);
            if (rating == null)
            {
                throw new Exception("rating not found");
            }
            
            var updated_rating = _mapper.Map<Rating>(request.UpdateRatingDto);
            await _ratingRepository.Update(updated_rating);
            return updated_rating;
        }

    }
}