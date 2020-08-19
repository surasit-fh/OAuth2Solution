using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using OAuth2.Model.Enums;
using OAuth2.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.Model.Models.MongoDBs
{
    public class UserModel
    {
        [BsonIgnoreIfNull]
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId UserId { get; set; }

        [BsonIgnoreIfNull]
        public string FirstName { get; set; }

        [BsonIgnoreIfNull]
        public string LastName { get; set; }

        [BsonIgnoreIfNull]
        public string Username { get; set; }

        [BsonIgnoreIfNull]
        public string Password { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.String)]
        public UserRole UserRole { get; set; }

        [BsonIgnoreIfNull]
        public string Code { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
    }
}