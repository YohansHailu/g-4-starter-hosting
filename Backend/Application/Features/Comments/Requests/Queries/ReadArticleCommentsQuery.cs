using MediatR;
using Application.Responses;
using System;
using Application.DTOs.Comment;
using Domain;

namespace Application.Features.Comments.Requests.Queries
{
    public class ReadArticleCommentsQuery : IRequest<List<Comment>>
    {
        public Guid ArticleID { get; set; }
    }
}
