using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.EventCategoryDtos;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServ.Dtos.BookingDtos
{
    public class ResultBookingDto
    {
        public string BookingId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string NameSurname { get; set; }
        public string EventCategoryId { get; set; }
        public ResultEventCategoryDto EventCategory { get; set; }
        public string PersonCount { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
    }
}
