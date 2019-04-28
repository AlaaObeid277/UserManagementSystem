using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementSystem.Model
{
    public class Geo
    {
        [BsonElement("lat")]
        public decimal Lat { get; set; }

        [BsonElement("lng")]
        public decimal Lng { get; set; }
    }
}
