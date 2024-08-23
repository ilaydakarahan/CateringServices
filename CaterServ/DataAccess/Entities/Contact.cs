using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        public string Adress { get; set; }
        public string MailUs { get; set; }
        public string Phone { get; set; }
    }
}
