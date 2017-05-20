using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using ROSys.Model;

namespace ROSys.MongoDBFacade
{
    internal class MongoDBEntity<T> : IMongoDBEntity
    {
        public ObjectId Id { get; set; }
        public IEntity  Data { get; set; }
    }
}
