using LoginAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly JwtTokenService _jwtTokenService;

    public LoginController(IUserService userService, JwtTokenService jwtTokenService)
    {
        _userService = userService;
        _jwtTokenService = jwtTokenService;
    }

    // Login endpoint with clear error handling and security improvements
    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return BadRequest("Email and password are required."); // Validate input
        }

        var users = await _userService.AuthenticateAsync(username, password);

        if (users == null)
        {
            return Unauthorized("Invalid email or password."); // Use Unauthorized for authentication failure
        }

        // Generate JWT token
        var token = _jwtTokenService.GenerateToken(users);
        return Ok(new
        {
            User = new
            {
                users.UserID,
                users.Username,
                users.Email
            },
            Token = token
        }); // Return essential user details and token
    }

    // Get all users endpoint
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminEndpoint()
    {
        return Ok("This is an Admin-only endpoint.");
    }

    [Authorize(Roles = "User")]
    [HttpGet("user")]
    public IActionResult UserEndpoint()
    {
        return Ok("This is a User-only endpoint.");
    }



}
