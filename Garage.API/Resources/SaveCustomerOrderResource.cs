using System.ComponentModel.DataAnnotations;

namespace Garage.API.Resources
{
    public class SaveCustomerOrderResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
