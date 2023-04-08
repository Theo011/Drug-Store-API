using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<Insurance, InsuranceDto>();
            CreateMap<InsuranceDto, Insurance>();
            CreateMap<InsuranceForCreationAndUpdateDto, Insurance>();
            CreateMap<Insurance, InsuranceForCreationAndUpdateDto>();
        }
    }
}