using Application.Contracts;
using Application.Features.Ratings.Requests.Commands;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Ratings.Handlers.Commands
{
    public class CreateRatingRequestHandler : IRequestHandler<CreateRatingCommand, Unit>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public CreateRatingRequestHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Rating>(request.CreateRatingDto);
            rating = await _ratingRepository.Add(rating);
            return Unit.Value;
        }
    }
}