using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.EventCategoryDtos;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServ.Dtos.EventDtos
{
    public class ResultEventDto
    {
        public string EventId { get; set; }
        public string ImageUrl { get; set; }
        //public string EventCategoryName { get; set; }
        public string EventCategoryId { get; set; }
        public ResultEventCategoryDto EventCategory { get; set; }
    }
}
