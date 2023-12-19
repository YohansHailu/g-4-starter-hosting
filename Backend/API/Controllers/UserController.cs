using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using Domain;
using API.Services;
using Application.DTOs.userAuthDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{

    private readonly UserManager<User> _userManager;
    private readonly AuthenticationTokenService _tokenService;

    public UserController(UserManager<User> userManager, AuthenticationTokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;

    }
    

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users
                    .FirstOrDefaultAsync(x => x.Email == loginDto.Email);

        if (user == null) return Unauthorized("Wrong email");

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (result)
        {
            return Ok(_tokenService.CreateUserWithToken(user));
        }
        return Unauthorized("Wrong Password");
    }

    [Authorize]
    [HttpGet("all")]
    public IActionResult GetAllUsers()
    {
        return Ok(_userManager.Users.ToList());
    }

    [Authorize]
    [HttpGet("testAuth")]
    public IActionResult AuthTest()
    {
        return Ok("authorization is working");
    }


    [HttpPost("register")]
    public async Task<IActionResult> AddUser([FromBody] RegisterDto userDot)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return BadRequest(errors);
        }

        var existingEmail = await _userManager.FindByEmailAsync(userDot.email);
        if (existingEmail != null)
        {
            ModelState.AddModelError("Email", "Email already exits");
        }

        var existingUserName = await _userManager.FindByNameAsync(userDot.userName);
        if (existingEmail != null)
        {
            ModelState.AddModelError("user-name", "user-name already exits");
        }

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return BadRequest(errors);
        }


        var user = new User
        {
            Email = userDot.email,
            UserName = userDot.userName,
            Name = userDot.name,
        };

        var res = await _userManager.CreateAsync(user, userDot.password);
        if (!res.Succeeded)
        {
            return BadRequest(res.Errors.Select((e => e.Description)));
        }

        return Ok(_tokenService.CreateUserWithToken(user));
    }

    [Authorize]
    [HttpGet("current-user")]
    public async Task<IActionResult> GetCurrentUser()
    {

        var user = await _userManager.Users
        .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));
        if (user == null)
        {
            return Unauthorized();
        }
        
        return Ok(user);
    }
}
