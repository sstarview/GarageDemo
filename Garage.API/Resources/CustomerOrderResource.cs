using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.API.Resources
{
    public class CustomerOrderResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CustomerId { get; set; }
    }
}
