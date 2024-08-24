using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.CheffDtos;

namespace CaterServ.Mapping
{
    public class CheffMapping : Profile
    {
        public CheffMapping()
        {
            CreateMap<ResultCheffDto, Cheff>().ReverseMap();
            CreateMap<CreateCheffDto, Cheff>().ReverseMap();
            CreateMap<UpdateCheffDto, Cheff>().ReverseMap();
            CreateMap<ResultCheffDto, UpdateCheffDto>().ReverseMap();
        }
    }
}
