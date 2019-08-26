using System.Collections.Generic;

namespace Garage.API.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerType = ECustomerType.Regular;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public ECustomerType CustomerType { get; set; }




        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Discount> Discounts { get; set; }


    }

}
