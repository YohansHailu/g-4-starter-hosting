using MediatR;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Contracts;
using Application.Features.Comments.Requests.Queries;
using Application.DTOs.Comment;
using AutoMapper;
using Domain;


namespace Application.Features.Comments.Handlers.Queries
{
    public class ReadRepliedCommentsQueryHandler : IRequestHandler<ReadRepliedCommentsQuery, List<Comment>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;


        public ReadRepliedCommentsQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<Comment>>  Handle(ReadRepliedCommentsQuery request, CancellationToken cancellationToken)
        {
            

            var repliedComments = await _commentRepository.GetRepliedComments(request.ParentCommentID);


            return repliedComments.ToList();
        }
    }
}
