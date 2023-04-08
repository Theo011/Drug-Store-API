using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class ProductReceiptProfile : Profile
    {
        public ProductReceiptProfile()
        {
            CreateMap<ProductReceipt, ProductReceiptDto>();
            CreateMap<ProductReceiptDto, ProductReceipt>();
            CreateMap<ProductReceiptForCreationAndUpdateDto, ProductReceipt>();
            CreateMap<ProductReceipt, ProductReceiptForCreationAndUpdateDto>();
        }
    }
}