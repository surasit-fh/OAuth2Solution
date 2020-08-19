using MongoDB.Driver;
using OAuth2.Model.Models.MongoDBs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.DAL.Services
{
    internal static class MongoDBCollections
    {
        internal static IMongoCollection<UserModel> UsersCollection
        {
            get { return MongoDBService.ConnectMongoDB.GetCollection<UserModel>("Users"); }
        }
    }
}