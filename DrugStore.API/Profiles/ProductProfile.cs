using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductForCreationAndUpdateDto, Product>();
            CreateMap<Product, ProductForCreationAndUpdateDto>();
        }
    }
}