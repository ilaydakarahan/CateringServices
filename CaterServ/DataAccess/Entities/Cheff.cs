using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class Cheff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CheffId { get; set; }
        public string CheffName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
