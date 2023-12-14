using Application.Contracts;
using Application.Features.Ratings.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Ratings.Handlers.Commands
{
    public class DeleteRatingRequestHandler : IRequestHandler<DeleteRatingCommand, Unit>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public DeleteRatingRequestHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.Get(request.Id);
            await _ratingRepository.Delete(rating);

            return Unit.Value;
        }

    }
}