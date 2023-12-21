using API.Services;
using Application.DTOs.Blog;
using Application.Exceptions;
using Application.Features.Blog.Commands.CreateBlog;
using Application.Features.Blog.Commands.DeleteBlog;
using Application.Features.Blog.Commands.UpdateBlog;
using Application.Features.Blog.Queries.GetAllBlogs;
using Application.Features.Blog.Queries.GetBlogDetails;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IAuthenticatedUserService _userService;
    public BlogController(IMediator mediator, IMapper mapper, IAuthenticatedUserService userService)
    {
        this._mediator = mediator;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<BlogDetailsDto>> Get()
    {
        var result = await _mediator.Send(new GetAllBlogsQuery());
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogDto>> Get(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetBlogDetailsQuery(id));
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize]
    public async Task<ActionResult<BlogDetailsDto>> Create(CreateBlogDto newBlog)
    {
        try
        {
            var blog = _mapper.Map<BlogDto>(newBlog);
            blog.AutherId = _userService.GetUserId(User);
                
            var command = new CreateBlogCommand{BlogDto = blog};
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        catch (BadRequestException)
        {
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize]
    public async Task<ActionResult<BlogDto>> Update(Guid id, UpdateBlogCommand blog)
    {
        try
        {
            blog.Id = id;
            var result = await _mediator.Send(blog);
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (BadRequestException)
        {
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {

        try
        {
            await _mediator.Send(new DeleteBlogCommand { Id = id });
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
