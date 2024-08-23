using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServ.DataAccess.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
    }
}
