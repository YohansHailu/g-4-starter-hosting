using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Comment;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Handlers.Queries;
using Application.Features.Comments.Requests.Commands;
using Application.Features.Comments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Responses;

namespace API.Controllers
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
        [Authorize]
        [ProducesResponseType(200, Type = typeof(SuccessResponse<object>))] // Assuming SuccessResponse has a generic type
        [ProducesResponseType(400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> LeaveComment([FromBody] LeaveCommentDTO leaveCommentDTO)
        {
            try
            {
                var command = new LeaveCommentCommand
                {
                    LeaveCommentDTO = leaveCommentDTO,
                    AuthorID = Guid.Parse(User.FindFirst("sub")?.Value ?? throw new InvalidOperationException("User ID not found"))
                };

                var response = await _mediator.Send(command);

                if (response.Success)
                {
                    return Ok(new SuccessResponse<object> { ID = response.ID, Data = response.Data, Message = response.Message });
                }

                return BadRequest(new ErrorResponse { Errors = response.Errors, Message = response.Message });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return StatusCode(500, new ErrorResponse { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpPost("reply")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(SuccessResponse<object>))]
        [ProducesResponseType(400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ReplyToComment([FromBody] ReplyToCommentDTO replyToCommentDTO)
        {
            try
            {
                var command = new ReplyToCommentCommand
                {
                    ReplyToCommentDTO = replyToCommentDTO,
                    AuthorID = Guid.Parse(User.FindFirst("sub")?.Value ?? throw new InvalidOperationException("User ID not found"))
                };

                var response = await _mediator.Send(command);

                if (response.Success)
                {
                    return Ok(new SuccessResponse<object> { Data = response.Data, Message = response.Message});
                }

                return BadRequest(new ErrorResponse { Errors = response.Errors, Message = response.Message });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return StatusCode(500, new ErrorResponse { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpPut("update")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(SuccessResponse<object>))]
        [ProducesResponseType(400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            try
            {
                var command = new UpdateCommentCommand
                {
                    UpdateCommentDTO = updateCommentDTO,
                    AuthorID = Guid.Parse(User.FindFirst("sub")?.Value ?? throw new InvalidOperationException("User ID not found"))
                };

                var response = await _mediator.Send(command);

                if (response.Success)
                {
                    return Ok(new SuccessResponse<object> { Data = response.Data , Message = "Comment updated successfully" });
                }

                return BadRequest(new ErrorResponse { Errors = response.Errors, Message = response.Message });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return StatusCode(500, new ErrorResponse { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpDelete("delete")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(SuccessResponse<object>))]
        [ProducesResponseType(400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentDTO deleteCommentDTO)
        {
            try
            {
                var command = new DeleteCommentCommand
                {
                    DeleteCommentDTO = deleteCommentDTO,
                    AuthorID = Guid.Parse(User.FindFirst("sub")?.Value ?? throw new InvalidOperationException("User ID not found"))
                };

                var response = await _mediator.Send(command);

                if (response.Success)
                {
                    return Ok(new SuccessResponse<object> { Message = response.Message });
                }

                return BadRequest(new ErrorResponse { Errors = response.Errors, Message = "Failed to delete comment" });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return StatusCode(500, new ErrorResponse { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpGet("{articleID}")]
        [ProducesResponseType(200, Type = typeof(SuccessResponse<object>))]
        [ProducesResponseType(404, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ReadArticleComments(Guid articleID)
        {
            try
            {
                var query = new ReadArticleCommentsQuery { ArticleID = articleID };
                var comments = await _mediator.Send(query);

                if (comments.Count != 0)
                {
                    return Ok(new SuccessResponse<object> { Data = new { Comments = comments.Select(comment => comment) } });
                }

                return NotFound(new ErrorResponse { Message = "Comments not found" });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return StatusCode(500, new ErrorResponse { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpGet("replied/{parentCommentID}")]
        [ProducesResponseType(200, Type = typeof(SuccessResponse<object>))]
        [ProducesResponseType(404, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ReadRepliedComments(Guid parentCommentID)
        {
            try
            {
                var query = new ReadRepliedCommentsQuery { ParentCommentID = parentCommentID };
                var comments = await _mediator.Send(query);

                if (comments.Count != 0)
                {
                    return Ok(new SuccessResponse<object> { Data = new { RepliedComments = comments.Select(comment => comment) } });
                }

                return NotFound(new ErrorResponse { Message = "Replied Comments not found" });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return StatusCode(500, new ErrorResponse { Message = "Internal Server Error", Error = ex.Message });
            }
        }
    }
}
