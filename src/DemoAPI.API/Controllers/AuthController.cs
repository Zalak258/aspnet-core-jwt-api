using DemoAPI.Infrastructure.Data;
using DemoAPI.Services;
using DemoAPI.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using DemoAPI.Core.DTOs;

namespace DemoAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Username))
                    return BadRequest("Username is required");

                if (_context.Users.Any(x => x.Username == user.Username))
                    return BadRequest("Username already exists");

                // Password validation
                var password = user.Password;

                if (string.IsNullOrWhiteSpace(password))
                    return BadRequest("Password is required");

                if (password.Length < 8)
                    return BadRequest("Password must be at least 8 characters long");

                if (!password.Any(char.IsUpper))
                    return BadRequest("Password must contain at least one uppercase letter");

                if (!password.Any(char.IsLower))
                    return BadRequest("Password must contain at least one lowercase letter");

                if (!password.Any(char.IsDigit))
                    return BadRequest("Password must contain at least one number");

                if (!password.Any(ch => "!@#$%^&*()_-+=<>?".Contains(ch)))
                    return BadRequest("Password must contain at least one special character");

                var newUser = new User
                {
                    Username = user.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "User created successfully",
                    Data = newUser.Username
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Data = null
                });
            }
            
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto user)
        {
            try
            {
                var dbUser = _context.Users
                .FirstOrDefault(x => x.Username == user.Username);

                // Check user exists first 
                if (dbUser == null)
                    return NotFound("User does not exist");

                // Check password
                if (!BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password))
                    return Unauthorized("Invalid password");

                var token = _tokenService.CreateToken(user.Username);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Login successful",
                    Data = token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Data = null
                });
            }           
        }
    }
}