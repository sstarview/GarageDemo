using Garage.API.Domain.Models;
using Garage.API.Domain.Repositories;
using Garage.API.Domain.Services;
using Garage.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            return await _customerRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();
                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occured while saving the customer {ex.Message}");

            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
            {
                return new CustomerResponse("Customer Not Found");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.MobileNumber = customer.MobileNumber;

            try
            {
                _customerRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when updating the customer: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
            {
                return new CustomerResponse("Customer not found");
            }

            try
            {
                _customerRepository.Remove(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when deleting the customer: {ex.Message}");

            }
        }
    }
}
