using Garage.API.Domain.Models;
using Garage.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<Customer> FindByIdAsync(int id);
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        Task<CustomerResponse> DeleteAsync(int id);
    }
}
