using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.EventDtos;

namespace CaterServ.Mapping
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<ResultEventDto, Event>().ReverseMap();
            CreateMap<CreateEventDto, Event>().ReverseMap();
            CreateMap<UpdateEventDto, Event>().ReverseMap();
            CreateMap<ResultEventDto, UpdateEventDto>().ReverseMap();
        }
    }
}
