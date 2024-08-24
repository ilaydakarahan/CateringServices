using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.BookingDtos;

namespace CaterServ.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, UpdateBookingDto>().ReverseMap();
        }
    }
}
