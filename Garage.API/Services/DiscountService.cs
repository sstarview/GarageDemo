using Garage.API.Domain.Models;
using Garage.API.Domain.Repositories;
using Garage.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.API.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<IEnumerable<Discount>> ListAsync()
        {
            return await _discountRepository.ListAsync();
        }
    }
}
