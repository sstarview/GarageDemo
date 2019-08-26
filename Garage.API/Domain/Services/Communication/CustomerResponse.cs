using Garage.API.Domain.Models;

namespace Garage.API.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }

        private CustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            Customer = customer;
        }

        public CustomerResponse(Customer customer)
            : this(true, string.Empty, customer)
        {
        }

        public CustomerResponse(string message)
            : this(false, message, null)
        {
        }
    }
}
