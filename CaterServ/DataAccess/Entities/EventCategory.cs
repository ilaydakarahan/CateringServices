using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class EventCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventCategoryId { get; set; }
        public string CategoryName { get; set; }

        [BsonIgnore]
        public List<Event> Events { get; set; }
    }
}
