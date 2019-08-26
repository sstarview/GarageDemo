using AutoMapper;
using Garage.API.Domain.Models;
using Garage.API.Resources;

namespace Garage.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();

            CreateMap<Order, CustomerOrderResource>();

        }
    }
}
