using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Point {  get; set; }
        public string Comment { get; set; }

    }
}
