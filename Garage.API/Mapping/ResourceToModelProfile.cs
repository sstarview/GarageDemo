using AutoMapper;
using Garage.API.Domain.Models;
using Garage.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveCustomerOrderResource, Order>();
        }
    }
}
