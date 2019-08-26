using AutoMapper;
using Garage.API.Domain.Models;
using Garage.API.Domain.Services;
using Garage.API.Extensions;
using Garage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Controllers
{
    [Route("api/customers/{customerid}/[controller]")]
    [ApiController]
    public class CustomerOrdersController : ControllerBase
    {
       

        private readonly ICustomerOrderService _customerOrderService;
        private readonly IMapper _mapper;
        private Discount discount = new Discount();

        public CustomerOrdersController(ICustomerOrderService customerOrderService, IMapper mapper)
        {
            _customerOrderService = customerOrderService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrderResource>>> GetAllAsync(int customerId)
        {
            //finding customer by customerid
            var customer = await _customerOrderService.FindCustomerAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var orders = await _customerOrderService.ListAsync(customerId);

            var resource = _mapper.Map<ActionResult<IEnumerable<Order>>, ActionResult<IEnumerable<CustomerOrderResource>>>(orders);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int customerId, [FromBody] SaveCustomerOrderResource resource)
        {
            var customer = await _customerOrderService.FindCustomerAsync(customerId);


            if (customer == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var order = _mapper.Map<SaveCustomerOrderResource, Order>(resource);
            //public Discount discount;


            var result = await _customerOrderService.SaveAsync(customerId, order, customer, discount);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            var customerOrderResource = _mapper.Map<Order, CustomerOrderResource>(result.Order);

            return Ok(customerOrderResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int customerId, int id, [FromBody] SaveCustomerOrderResource resource)
        {
            var customer = await _customerOrderService.FindCustomerAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var order = _mapper.Map<SaveCustomerOrderResource, Order>(resource);
            var result = await _customerOrderService.UpdateAsync(id, order);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerOrderResource = _mapper.Map<Order, SaveCustomerOrderResource>(result.Order);
            return Ok(customerOrderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int customerId, int id)
        {
            var customer = await _customerOrderService.FindCustomerAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var result = await _customerOrderService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var orderResource = _mapper.Map<Order, CustomerOrderResource>(result.Order);
            return Ok(orderResource);
        }
    }
}