﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementSystem.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("website")]
        public string Website { get; set; }

        [BsonElement("company")]
        public Company Company { get; set; }
    }
}
