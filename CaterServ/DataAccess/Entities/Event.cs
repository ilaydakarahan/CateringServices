﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using CaterServ.Dtos.EventCategoryDtos;

namespace CaterServ.DataAccess.Entities
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
        public string ImageUrl { get; set; }
        public string EventCategoryName { get; set; }
        public string EventCategoryId { get; set; }

        [BsonIgnore]
        public EventCategory EventCategory { get; set; }
    }
}
