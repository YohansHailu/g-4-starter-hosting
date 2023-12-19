using MediatR;
using Application.Responses;
using System;
using Application.DTOs.Comment;
using Domain;

namespace Application.Features.Comments.Requests.Queries
{
    public class ReadRepliedCommentsQuery : IRequest<List<Comment>>
    {
        public Guid ParentCommentID { get; set; }
    }
}
