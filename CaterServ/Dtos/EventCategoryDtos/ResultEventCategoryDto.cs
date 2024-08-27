using CaterServ.DataAccess.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServ.Dtos.EventCategoryDtos
{
    public class ResultEventCategoryDto
    {
        public string EventCategoryId { get; set; }
        public string EventCategoryName { get; set; }

        //[BsonIgnore]
        //public List<Event> Events { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
