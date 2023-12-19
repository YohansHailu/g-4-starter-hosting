using Application.DTOs.Blog;
using Application.Exceptions;
using Application.Features.Blog.Commands.CreateBlog;
using Application.Features.Blog.Commands.DeleteBlog;
using Application.Features.Blog.Commands.UpdateBlog;
using Application.Features.Blog.Queries.GetAllBlogs;
using Application.Features.Blog.Queries.GetBlogDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BlogController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<BlogDto>> Get()
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
        catch(NotFoundException)
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
    public async Task<ActionResult<BlogDetailsDto>> Create(CreateBlogCommand blog)
    {
        try
        {
            var result = await _mediator.Send(blog);
            return CreatedAtAction(nameof(Get), new { id = result.id }, result);
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
    public async Task<ActionResult> Delete(Guid id)
    {
       
        try
        {
            await _mediator.Send(new DeleteBlogCommand {Id = id});
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