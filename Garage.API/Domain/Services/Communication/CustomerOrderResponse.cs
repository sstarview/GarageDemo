using Garage.API.Domain.Models;

namespace Garage.API.Domain.Services.Communication
{
    public class CustomerOrderResponse : BaseResponse
    {
        public Order Order { get; private set; }


        public CustomerOrderResponse(bool success, string message, Order order)
             : base(success, message)
        {
            Order = order;

        }

        public CustomerOrderResponse(Order order)
            : this(true, string.Empty, order)
        {

        }

        public CustomerOrderResponse(string message)
            : this(false, message, null)
        {

        }


    }
}
