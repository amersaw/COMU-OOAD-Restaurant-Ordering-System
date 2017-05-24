using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.MongoDBFacade
{
    public interface IMongoDBEntity
    {
        ObjectId Id { get; set; }
        Model.IEntity Data { get; set; }
    }
}
