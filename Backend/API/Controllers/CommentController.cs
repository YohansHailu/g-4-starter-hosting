using System;
using System.Threading.Tasks;
using Application.DTOs.Comment;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Handlers.Queries;
using Application.Features.Comments.Requests.Commands;
using Application.Features.Comments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("leave")]
        public async Task<IActionResult> LeaveComment([FromBody] LeaveCommentDTO leaveCommentDTO)
        {
            var command = new LeaveCommentCommand { LeaveCommentDTO = leaveCommentDTO };
            var response = await _mediator.Send(command);

            return response.Success
                ? Ok(new { CommentID = response.ID, Message = response.Message })
                : BadRequest(new { Errors = response.Errors });
        }

        [HttpPost("reply")]
        public async Task<IActionResult> ReplyToComment([FromBody] ReplyToCommentDTO replyToCommentDTO)
        {
            var command = new ReplyToCommentCommand { ReplyToCommentDTO = replyToCommentDTO };
            var comment = await _mediator.Send(command);


            return comment != null
        ? Ok(new { Comment = comment })  // Serializing the comment to JSON
        : BadRequest(new { Message = "Failed to create reply comment" });
                
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            var command = new UpdateCommentCommand { UpdateCommentDTO = updateCommentDTO };
            var comment = await _mediator.Send(command);

            return comment != null
        ? Ok(new { Comment = comment })  // Serializing the comment to JSON
        : BadRequest(new { Message = "Failed to create reply comment" });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentDTO deleteCommentDTO)
        {
            var command = new DeleteCommentCommand { DeleteCommentDTO = deleteCommentDTO };
            var response = await _mediator.Send(command);

            return response.Success
                ? Ok(new { Message = response.Message })
                : BadRequest(new { Errors = response.Errors });
        }

        [HttpGet("{articleID}")]
        public async Task<IActionResult> ReadArticleComments(Guid articleID)
        {
            var query = new ReadArticleCommentsQuery { ArticleID = articleID };
            var comments = await _mediator.Send(query);

            
            return comments.Count != 0
                ? Ok(new { Comments = comments.Select(comment => comment ) })  // Serializing each comment to JSON
                : NotFound(new { Message = "Comments not found" });
        }

        [HttpGet("replied/{parentCommentID}")]
        public async Task<IActionResult> ReadRepliedComments(Guid parentCommentID)
        {
            var query = new ReadRepliedCommentsQuery { ParentCommentID = parentCommentID };
            var comments = await _mediator.Send(query);

            
            return comments.Count != 0
                ? Ok(new { RepliedComments = comments.Select(comment => comment ) })  // Serializing each comment to JSON
                : NotFound(new { Message = "Replied Comments not found" });
        }
    }
}
