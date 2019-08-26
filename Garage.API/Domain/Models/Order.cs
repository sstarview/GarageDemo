namespace Garage.API.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Discount Discount { get; set; }
    }
}