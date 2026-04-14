using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Core.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }
    }
}