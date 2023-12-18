using Application.DTOs.Rating;
using Application.DTOs.UserProfile;
using Application.Features.Ratings.Requests.Commands;
using Application.Features.Ratings.Requests.Queries;
using Application.Features.UserProfile.Requests.Command;
using Application.Features.UserProfile.Requests.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController: ControllerBase
{
    private readonly IMediator _mediator;
    public UserProfileController(IMediator mediator)
    {
        this._mediator = mediator;
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Rating>> Get(Guid id)
    {
        var result = await _mediator.Send(new GetUserProfileRequest(){Id = id});
        return Ok(result);
    }
    [HttpGet("By-user-Id/{userId:guid}")]
    public async Task<ActionResult<Rating>> GetByUserId(Guid userId)
    {
        var command = new GetUserProfileByUserIdRequest() { UserId = userId };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] UserProfileDto user)
    {
        var command = new CreateUserProfileCommand(){ UserProfileDto= user};
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UserProfileDto user)
    {
        var command = new UpdateUserProfileCommand(){ UserProfileDto = user};
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        
        Console.Write("am here in delte handler with Id " + id);
        var command = new DeleteUserProfileCommand(){ Id = id};
        var userProfile = await _mediator.Send(command);
        return Ok(userProfile);
    }
}
