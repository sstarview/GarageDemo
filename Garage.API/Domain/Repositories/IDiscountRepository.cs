using Garage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.API.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> ListAsync();
        Task AddAsync(Discount discount);
    }
}
