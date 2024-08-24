using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.ServiceDtos;

namespace CaterServ.Mapping
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, UpdateServiceDto>().ReverseMap();
        }
    }
}
