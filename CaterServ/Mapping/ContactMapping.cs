using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.ContactDtos;

namespace CaterServ.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, UpdateContactDto>().ReverseMap();
        }
    }
}
