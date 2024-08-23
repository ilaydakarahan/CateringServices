using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.CategoryDtos;

namespace CaterServ.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, UpdateCategoryDto>().ReverseMap();
        }
    }
}
