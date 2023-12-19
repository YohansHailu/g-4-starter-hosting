using API.Services;
using Application.DTOs.Rating;
using Application.DTOs.UserProfile;
using Application.Features.Ratings.Requests.Commands;
using Application.Features.Ratings.Requests.Queries;
using Application.Features.UserProfile.Requests.Command;
using Application.Features.UserProfile.Requests.Queries;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IAuthenticatedUserService _userService;
    public UserProfileController(IMediator mediator, IAuthenticatedUserService userService, IMapper mapper)
    {
        this._mediator = mediator;
        _userService = userService;
        _mapper = mapper;
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
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Create([FromBody] CreateUserProfileDto newProfile)
    {
        var userProfile = _mapper.Map<UserProfileDto>(newProfile);
        userProfile.UserId = _userService.GetUserId(User);
        
        var command = new CreateUserProfileCommand(){ UserProfileDto = userProfile};
        var response = await _mediator.Send(command);
        
        return Ok(response);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Put([FromBody] CreateUserProfileDto newProfile)
    {
        var userProfile = _mapper.Map<UserProfileDto>(newProfile);
        userProfile.UserId = _userService.GetUserId(User);
        
        var command = new UpdateUserProfileCommand(){ UserProfileDto = userProfile};
        await _mediator.Send(command);
        return NoContent();
    }
    
    [Authorize]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteUserProfileCommand(){ Id = id};
        var userProfile = await _mediator.Send(command);
        return Ok(userProfile);
    }
}
