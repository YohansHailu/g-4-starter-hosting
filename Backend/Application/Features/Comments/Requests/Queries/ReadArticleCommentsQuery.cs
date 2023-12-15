using MediatR;
using Application.Responses;
using System;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Queries
{
    public class ReadArticleCommentsQuery : IRequest<List<CommentDTO>>
    {
        public Guid ArticleID { get; set; }
    }
}
