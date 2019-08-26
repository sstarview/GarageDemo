using Garage.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Domain.Repositories
{
    public interface ICustomerOrderRepository
    {
        Task<Customer> FindByIdAsync(int customerId);
        Task<ActionResult<IEnumerable<Order>>> ListAsync(int customerId);
        Task AddAsync(Order order);
        Task<Order> FindOrderByIdAsync(int id);
        void Update(Order order);
        void Remove(Order order);

        //int CountOrder(int customerId);
        //Task UpdateCustomerType(int customerId, Customer customer);
        //Task<int> CountOrder(int customerId);
        //void UpdateCustomer(Customer customer);
        Task<int> CountOrdersAsync(int customerId);
    }
}
