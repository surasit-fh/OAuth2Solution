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
    public class TokenModel
    {
        [BsonIgnoreIfNull]
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId TokenId { get; set; }

        [BsonIgnoreIfNull]
        public string AccessToken { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.String)]
        public TokenType TokenType { get; set; }

        [BsonIgnoreIfNull]
        public string ExpiresIn { get; set; }

        [BsonIgnoreIfNull]
        public string RefreshToken { get; set; }

        [BsonIgnoreIfNull]
        public string[] Scopes { get; set; }
    }
}