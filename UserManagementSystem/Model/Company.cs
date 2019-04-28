using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementSystem.Model
{
    public class Company
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("catchPhrase")]
        public string CatchPhrase { get; set; }

        [BsonElement("bs")]
        public string Bs { get; set; }
    }
}
