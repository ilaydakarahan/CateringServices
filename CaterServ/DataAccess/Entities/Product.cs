using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }

        [BsonIgnore]    //verilere erişmek için yaptık.veritabanına yansıtmıyoruz.
        public Category Category { get; set; }      //ilişki kurma
    }
}
