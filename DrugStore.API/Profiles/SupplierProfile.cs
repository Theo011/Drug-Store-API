using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();
            CreateMap<SupplierForCreationAndUpdateDto, Supplier>();
            CreateMap<Supplier, SupplierForCreationAndUpdateDto>();
        }
    }
}