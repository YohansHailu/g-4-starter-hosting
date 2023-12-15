using Application.DTOs.Blog;
using Application.DTOs.Rating;
using Application.Features.Blog.Commands.CreateBlog;
using Application.Features.Blog.Commands.DeleteBlog;
using Application.Features.Blog.Commands.UpdateBlog;
using Application.Features.Blog.Queries.GetAllBlogs;
using Application.Features.Blog.Queries.GetBlogDetails;
using Application.Features.Ratings.Requests.Commands;
using Application.Features.Ratings.Requests.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
{
    private readonly IMediator _mediator;
    public RatingController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<RatingDto>> GetAllRatings(Guid id)
    {
        var result = await _mediator.Send(new GetRatingListRequest {BlogId = id});
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Rating>> Get(Guid id)
    {
        var result = await _mediator.Send(new GetRatingDetailRequest{Id = id});
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] RatingDto Rating)
    {
        var command = new CreateRatingCommand { CreateRatingDto = Rating };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] RatingDto Rating)
    {
        var command = new UpdateRatingCommand { UpdateRatingDto = Rating };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<RatingController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(RatingDto Rating)
    {
        var command = new DeleteRatingCommand { Id = Rating.Id };
        await _mediator.Send(command);
        return NoContent();
    }
}