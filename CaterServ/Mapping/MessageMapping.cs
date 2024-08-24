using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.MessageDtos;

namespace CaterServ.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<ResultMessageDto, Message>().ReverseMap();
            CreateMap<CreateMessageDto, Message>().ReverseMap();
        }
    }
}
