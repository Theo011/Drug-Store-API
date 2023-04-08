using AutoMapper;
using DrugStore.API.Entities;
using DrugStore.API.Models;

namespace DrugStore.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryForCreationAndUpdateDto, Category>();
            CreateMap<Category, CategoryForCreationAndUpdateDto>();
        }
    }
}