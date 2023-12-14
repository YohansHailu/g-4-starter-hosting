using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Identity;

using Domain;
using API.Controllers.Dto;
using API.Services;

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

    public UserDto createUserWithToken(User user)
    {
        var token = _tokenService.CreateToken(user);

        return new UserDto
        {
            Token  = token,
            Username = user.UserName
        };

    }
    
    
    [HttpGet("all")]
    public IActionResult GetAllUsers()
    {
        return Ok(_userManager.Users.ToList());
    }
    
    
    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] RegisterDto userDot)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return BadRequest(errors);
        }

        var existingEmail = await  _userManager.FindByEmailAsync(userDot.email);
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
            UserName= userDot.userName,
            Name = userDot.name,
        };

        var res = await _userManager.CreateAsync(user, userDot.password);
        if (!res.Succeeded)
        {
            return BadRequest(res.Errors.Select((e => e.Description)));
        }
        
        return Ok(createUserWithToken(user));
    }
}