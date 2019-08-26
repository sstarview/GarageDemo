using Garage.API.Domain.Models;
using Garage.API.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Domain.Services
{
    public interface ICustomerOrderService
    {
        Task<ActionResult<IEnumerable<Order>>> ListAsync(int customerId);
        Task<Customer> FindCustomerAsync(int customerId);
        Task<CustomerOrderResponse> SaveAsync(int customerId, Order order, Customer customer, Discount discount);
        Task<CustomerOrderResponse> UpdateAsync(int id, Order order);
        Task<CustomerOrderResponse> DeleteAsync(int id);

        //int CountOrder(int customerId);
        //void UpdateCustomerType(Customer customer);

        //Task<CustomerResponse> UpdateCustomerType(int customerId, Customer customer);

    }
}
