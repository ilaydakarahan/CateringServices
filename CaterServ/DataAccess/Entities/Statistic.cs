using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServ.DataAccess.Entities
{
    public class Statistic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StatisticId { get; set; }

        public string Icon1 { get; set; }
        public string Title1 { get; set; }
        public string Amount1 { get; set; }

        public string Icon2 { get; set; }
        public string Title2 { get; set; }
        public string Amount2 { get; set; }

        public string Icon3 { get; set; }
        public string Title3 { get; set; }
        public string Amount3 { get; set; }
    }
}
