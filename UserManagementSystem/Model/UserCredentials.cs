using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementSystem.Model
{
    public class UserCredentials
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }
        [BsonElement("userName")]
        public string UserName { get; set;}
        [BsonElement("password")]
        public string Password { get; set; }
    }
}