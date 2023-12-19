using API.Services;
using Application.DTOs.Blog;
using Application.DTOs.Rating;
using Application.Features.Blog.Commands.CreateBlog;
using Application.Features.Blog.Commands.DeleteBlog;
using Application.Features.Blog.Commands.UpdateBlog;
using Application.Features.Blog.Queries.GetAllBlogs;
using Application.Features.Blog.Queries.GetBlogDetails;
using Application.Features.Ratings.Requests.Commands;
using Application.Features.Ratings.Requests.Queries;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IAuthenticatedUserService _userService;
    public RatingController(IMediator mediator, IMapper mapper, IAuthenticatedUserService userService)
    {
        this._mediator = mediator;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet("Blog/{id}")]
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
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateRatingDto newRating)
    {
        var rating = _mapper.Map<RatingDto>(newRating);
        rating.UserId = _userService.GetUserId(User);
        var command = new CreateRatingCommand { CreateRatingDto = rating };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Put([FromBody] UpdateRatingDto newRating)
    {
        var rating = _mapper.Map<UpdateRatingDto>(newRating);
        var command = new UpdateRatingCommand { UpdateRatingDto = rating };
        var updatedRating = await _mediator.Send(command);
        return Ok(updatedRating);
    }

    // DELETE api/<RatingController>/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteRatingCommand { Id = id};
        await _mediator.Send(command);
        return NoContent();
    }
}