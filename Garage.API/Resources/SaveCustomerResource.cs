using System.ComponentModel.DataAnnotations;

namespace Garage.API.Resources
{
    public class SaveCustomerResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string MobileNumber { get; set; }
    }
}
