using Application.Contracts;
using Application.Features.Ratings.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Ratings.Handlers.Commands
{
    public class UpdateRatingRequestHandler : IRequestHandler<UpdateRatingCommand, Unit>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public UpdateRatingRequestHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }



        public async Task<Unit> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
    
            var rating = await _ratingRepository.Get(request.UpdateRatingDto.Id);
            _mapper.Map(request.UpdateRatingDto, rating);
            await _ratingRepository.Update(rating);
            return Unit.Value;
        }

    }
}