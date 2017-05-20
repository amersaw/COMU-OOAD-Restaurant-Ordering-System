using MongoDB.Driver;
using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.MongoDBFacade
{
    internal class MongoConnectionHandler<T> where T : IMongoDBEntity
    {
        public IMongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler(ServerInfo info)
        {
            MongoCredential credential = MongoCredential.CreateCredential(info.DbName, info.DbUserName, info.DbPassword);

            MongoClientSettings settings = new MongoClientSettings()
            {
                Credentials = new[] { credential },
                Server = new MongoServerAddress(info.DbServerIP, info.DbPort)
            };

            MongoClient client = new MongoClient(settings);
            MongoCollection = client.GetDatabase(info.DbName).GetCollection<T>(typeof(T).GenericTypeArguments[0].Name);
        }
    }
}
