using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerForCreationAndUpdateDto, Customer>();
            CreateMap<Customer, CustomerForCreationAndUpdateDto>();
        }
    }
}