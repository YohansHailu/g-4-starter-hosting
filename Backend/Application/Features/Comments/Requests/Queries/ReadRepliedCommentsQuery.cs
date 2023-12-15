using MediatR;
using Application.Responses;
using System;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Queries
{
    public class ReadRepliedCommentsQuery : IRequest<List<CommentDTO>>
    {
        public Guid ParentCommentID { get; set; }
    }
}
