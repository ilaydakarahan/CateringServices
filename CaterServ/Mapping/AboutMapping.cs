using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.AboutDtos;

namespace CaterServ.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<CreateAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();
            CreateMap<ResultAboutDto,UpdateAboutDto>().ReverseMap();         
        }
    }
}
