using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.EventCategoryDtos;

namespace CaterServ.Mapping
{
    public class EventCategoryMapping : Profile
    {
        public EventCategoryMapping()
        {
            CreateMap<ResultEventCategoryDto, EventCategory>().ReverseMap();
            CreateMap<CreateEventCategoryDto, EventCategory>().ReverseMap();
            CreateMap<UpdateEventCategoryDto, EventCategory>().ReverseMap();
            CreateMap<ResultEventCategoryDto, UpdateEventCategoryDto>().ReverseMap();
        }
    }
}
