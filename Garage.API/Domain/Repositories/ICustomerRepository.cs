using Garage.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task AddAsync(Customer customer);
        Task<Customer> FindByIdAsync(int id);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
