using Garage.API.Domain.Models;
using Garage.API.Domain.Repositories;
using Garage.API.Domain.Services;
using Garage.API.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiscountRepository _discountRepository;

        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IDiscountRepository discountRepository)
        {
            _customerOrderRepository = customerOrderRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _discountRepository = discountRepository;
        }



        public async Task<Customer> FindCustomerAsync(int customerId)
        {
            return await _customerOrderRepository.FindByIdAsync(customerId);
        }

        public async Task<ActionResult<IEnumerable<Order>>> ListAsync(int customerId)
        {
            var orders = await _customerOrderRepository.ListAsync(customerId);

            return orders;

        }

        public async Task<CustomerOrderResponse> SaveAsync(int customerId, Order order, Customer newCustomerUpdate, Discount discount)
        {
            var customer = await _customerOrderRepository.FindByIdAsync(customerId);

            order.CustomerId = customer.Id;


            try
            {
                await _customerOrderRepository.AddAsync(order);


                await _unitOfWork.CompleteAsync();

                var countOrders = await _customerOrderRepository.CountOrdersAsync(customerId);

                if (countOrders >= 3 && countOrders < 6)
                {
                    newCustomerUpdate.CustomerType = ECustomerType.Gold;
                    customer.CustomerType = newCustomerUpdate.CustomerType;

                    discount.CustomerId = customer.Id;
                    discount.OrderId = order.Id;
                    discount.DiscountValue = (10 * order.Price) / 100;




                }
                else if (countOrders >= 6)
                {
                    newCustomerUpdate.CustomerType = ECustomerType.Platinum;
                    customer.CustomerType = newCustomerUpdate.CustomerType;

                    discount.CustomerId = customer.Id;
                    discount.OrderId = order.Id;
                    discount.DiscountValue = (20 * order.Price) / 100;
                }
                else
                {
                    discount.CustomerId = customer.Id;
                    discount.OrderId = order.Id;
                    discount.DiscountValue = 0;
                }

                _customerRepository.Update(newCustomerUpdate);
                await _discountRepository.AddAsync(discount);

                await _unitOfWork.CompleteAsync();



                return new CustomerOrderResponse(order);
            }
            catch (Exception ex)
            {

                return new CustomerOrderResponse($"An error occured while saving the customer order {ex.Message}");
            }
        }

        public async Task<CustomerOrderResponse> UpdateAsync(int id, Order order)
        {
            var existingOrder = await _customerOrderRepository.FindOrderByIdAsync(id);

            if (existingOrder == null)
            {
                return new CustomerOrderResponse("Order not found");
            }

            existingOrder.Name = order.Name;
            existingOrder.Price = order.Price;

            try
            {
                _customerOrderRepository.Update(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new CustomerOrderResponse(existingOrder);
            }
            catch (Exception ex)
            {

                return new CustomerOrderResponse($"An error occurred when updating the customer order: {ex.Message}");

            }
        }

        public async Task<CustomerOrderResponse> DeleteAsync(int id)
        {
            var existingOrder = await _customerOrderRepository.FindOrderByIdAsync(id);

            if (existingOrder == null)
            {
                return new CustomerOrderResponse("Order not found");
            }

            try
            {
                _customerOrderRepository.Remove(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new CustomerOrderResponse(existingOrder);
            }
            catch (Exception ex)
            {
                return new CustomerOrderResponse($"An error occurred when deleting the customer order: {ex.Message}");
            }

        }

        //public async Task<CustomerResponse> UpdateCustomerType(int customerId, Customer customer)
        //{
        //    var existingCustomer = await _customerOrderRepository.FindByIdAsync(customerId);
        //    var orderCount = await _customerOrderRepository.CountOrder(customerId);

        //    if (orderCount > 2)
        //    {
        //        existingCustomer.CustomerType = ECustomerType.Platinum;
        //    }

        //    try
        //    {
        //        _customerOrderRepository.UpdateCustomer(existingCustomer);
        //        await _unitOfWork.CompleteAsync();

        //        return new CustomerResponse(existingCustomer);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CustomerResponse($"An error occurred when updating the customer type: {ex.Message}");

        //    }
        //}
    }
}
