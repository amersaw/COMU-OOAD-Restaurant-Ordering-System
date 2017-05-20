using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;
using MongoDB.Driver;

namespace ROSys.MongoDBFacade
{
    public class EntityService<T> where T : IMongoDBEntity
    {
        MongoConnectionHandler<T> mongoConnectionHandler;

        public EntityService(ServerInfo info)
        {
            mongoConnectionHandler = new MongoDBFacade.MongoConnectionHandler<T>(info);
        }

        public T FindByGuid(Guid id)
        {
            return mongoConnectionHandler.MongoCollection.Find(_=>true).ToList()
                .Where(x => x.Data.Id.ToString() == id.ToString()).FirstOrDefault();
        }

        internal List<object> FindAll()
        {
            return mongoConnectionHandler.MongoCollection.Find(_ => true)
                .ToList()
                .Select(o => (object)o)
                .ToList();
        }

        internal void Create(object obj)
        {
            mongoConnectionHandler.MongoCollection.InsertOne((T)obj);
        }
    }
}
