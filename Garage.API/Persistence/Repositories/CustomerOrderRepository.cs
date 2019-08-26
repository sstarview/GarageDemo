using Garage.API.Domain.Models;
using Garage.API.Domain.Repositories;
using Garage.API.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.API.Persistence.Repositories
{
    public class CustomerOrderRepository : BaseRepository, ICustomerOrderRepository
    {
        public CustomerOrderRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<Customer> FindByIdAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task<ActionResult<IEnumerable<Order>>> ListAsync(int customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<Order> FindOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<int> CountOrdersAsync(int customerId)
        {
            return await _context.Orders.Where(c => c.CustomerId == customerId).CountAsync();
        }
    }
}
