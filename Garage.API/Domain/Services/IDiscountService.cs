using Garage.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Domain.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<Discount>> ListAsync();
    }
}
