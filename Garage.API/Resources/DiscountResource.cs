using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.API.Resources
{
    public class DiscountResource
    {
        public int Id { get; set; }
        public double DiscountValue { get; set; }
        public int CustomerId { get; set; }
        public CustomerResource Customer { get; set; }
        public CustomerOrderResource Order { get; set; }
    }
}
