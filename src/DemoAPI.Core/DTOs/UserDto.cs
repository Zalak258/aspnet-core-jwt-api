using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Core.DTOs
{
    public class UserDto
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}