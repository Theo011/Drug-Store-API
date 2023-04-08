using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            CreateMap<Receipt, ReceiptDto>();
            CreateMap<ReceiptDto, Receipt>();
            CreateMap<ReceiptForCreationAndUpdateDto, Receipt>();
            CreateMap<Receipt, ReceiptForCreationAndUpdateDto>();
        }
    }
}