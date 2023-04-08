using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<InvoiceForCreationAndUpdateDto, Invoice>();
            CreateMap<Invoice, InvoiceForCreationAndUpdateDto>();
        }
    }
}