using MediatR;
using Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Features.Comments.Requests.Queries;
using Application.DTOs.Comment;
using AutoMapper;
using Domain;


namespace Application.Features.Comments.Handlers.Queries
{
    public class ReadArticleCommentsQueryHandler : IRequestHandler<ReadArticleCommentsQuery, List<Comment>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public ReadArticleCommentsQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<Comment>>  Handle(ReadArticleCommentsQuery request, CancellationToken cancellationToken)
        {
            

            var comments = await _commentRepository.GetCommentsByArticleID(request.ArticleID);

            

            return comments.ToList();
        }
    }
}
