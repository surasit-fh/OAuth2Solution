using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.DAL.Services
{
    internal class MongoDBService
    {
        //private static string connectionString = "mongodb://admin:OAuth2POC@127.0.0.1:27017/OAuth2POC";
        private static string connectionString = "mongodb://admin:OAuth2POC@192.168.2.198:27017/OAuth2POC";

        internal static IMongoDatabase ConnectMongoDB
        {
            get
            {
                MongoUrl database = MongoUrl.Create(connectionString);
                MongoClientSettings settings = new MongoClientSettings()
                {
                    Server = database.Server,
                    ServerSelectionTimeout = database.ServerSelectionTimeout,
                    SocketTimeout = database.SocketTimeout,
                    Credential = MongoCredential.CreateCredential(database.DatabaseName, database.Username, database.Password)
                };

                MongoClient client = new MongoClient(settings);
                return client.GetDatabase(database.DatabaseName);
            }
        }
    }
}