using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class ProductInvoiceProfile : Profile
    {
        public ProductInvoiceProfile()
        {
            CreateMap<ProductInvoice, ProductInvoiceDto>();
            CreateMap<ProductInvoiceDto, ProductInvoice>();
            CreateMap<ProductInvoiceForCreationAndUpdateDto, ProductInvoice>();
            CreateMap<ProductInvoice, ProductInvoiceForCreationAndUpdateDto>();
        }
    }
}