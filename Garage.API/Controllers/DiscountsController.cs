using AutoMapper;
using Garage.API.Domain.Models;
using Garage.API.Domain.Services;
using Garage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DiscountResource>> GetAllAsync()
        {
            var discounts = await _discountService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Discount>, IEnumerable<DiscountResource>>(discounts);
            return resource;
        }
    }
}