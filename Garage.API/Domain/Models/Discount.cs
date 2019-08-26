namespace Garage.API.Domain.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public double DiscountValue { get; set; }

        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}