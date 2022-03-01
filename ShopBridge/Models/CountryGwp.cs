using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
    public class CountryGwp
    {
        [Key]
        public int Id { get; set; }

        public double transport { get; set; }
        public double liability { get; set; }
        public string otherInformation { get; set; }
    }
}
