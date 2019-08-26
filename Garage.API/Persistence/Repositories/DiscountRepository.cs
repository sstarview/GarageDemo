using Garage.API.Domain.Models;
using Garage.API.Domain.Repositories;
using Garage.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Persistence.Repositories
{
    public class DiscountRepository : BaseRepository, IDiscountRepository
    {
        public DiscountRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Discount>> ListAsync()
        {
            return await _context.Discounts.Include(p => p.Customer).Include(p => p.Order).ToListAsync();
        }

        public async Task AddAsync(Discount discount)
        {
            await _context.Discounts.AddAsync(discount);
        }

        
    }
}
