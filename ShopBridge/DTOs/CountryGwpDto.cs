using System.ComponentModel.DataAnnotations;

namespace ShopBridge.DTOs
{
    public class CountryGwpDto
    {
        [Required]
        public string Country { get; set; }
        public string LOB { get; set; }

        [Required]
        public int startYear { get; set; }

        [Required]
        public int endYear { get; set; }
    }
}
