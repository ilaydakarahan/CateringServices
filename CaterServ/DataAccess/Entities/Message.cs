using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MessageId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
