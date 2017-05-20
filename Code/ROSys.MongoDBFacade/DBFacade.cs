using MongoDB.Bson.Serialization.Conventions;
using ROSys.Contracts;
using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.MongoDBFacade
{
    public class DBFacade : IROSysDBFacade
    {
        #region ServerInfo
        private static ServerInfo serverInfo = null;
        private static ServerInfo MongoDBServerInfo
        {
            get
            {
                if (serverInfo == null)
                    serverInfo = LoadServerInfo();
                return serverInfo;
            }
        }

        private static ServerInfo LoadServerInfo()
        {
            return new ServerInfo()
            {
                DbServerIP = ConfigurationManager.AppSettings["DbServerIP"],
                DbPort = Convert.ToInt32(ConfigurationManager.AppSettings["DbPort"]),
                DbName = ConfigurationManager.AppSettings["DbName"],
                DbPassword = ConfigurationManager.AppSettings["DbPassword"],
                DbUserName = ConfigurationManager.AppSettings["DbUserName"]
            };
        }
        #endregion

        #region Constructores

        public DBFacade()
        {
            CustomerEntityService = new MongoDBFacade.EntityService<MongoDBEntity<Customer>>(MongoDBServerInfo);
            var pack = new ConventionPack { new GuidAsStringRepresentationConvention() };
            ConventionRegistry.Register("GuidAsString", pack, t => t == typeof(Customer));
        }
        #endregion

        #region MongoDbEntityServices
        EntityService<MongoDBEntity<Customer>> CustomerEntityService;
        #endregion

        #region Interface Implementaiton

        public object Get(Guid id, Type type)
        {
            return GetMapper(type).Get(id);
        }

        public List<object> GetAll(Type type)
        {
            return GetMapper(type).GetAll().Select(o => (object)((IMongoDBEntity)o).Data).ToList();
        }

        public bool Put(object obj)
        {
            return GetMapper(obj.GetType()).Put(obj);
        }

        #endregion

        #region Helper Methods

        private IMapper GetMapper(Type type)
        {
            if (type == typeof(Customer))
            {
                return new Mappers.CustomersMapper(CustomerEntityService);
            }
            throw new NotSupportedException();
        }

        #endregion
    }
}
