using ROSys.Contracts;
using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.MSSqlDBFacade
{
    public class DBFacade : IROSysDBFacade
    {
        private SqlConnection conn = null;


        #region Singleton Stuff

        private static DBFacade instance = null;

        private DBFacade()
        {
        }

        public static DBFacade Instance
        {
            get
            {
                if (instance == null)
                    instance = GenerateInstance();
                return instance;
            }
        }
        
        #endregion


        #region Interface Implementation

        public object Get(Guid id, Type type)
        {
            IMapper mapper = GetMapper(type);
            return mapper.Get(id);
        }

        public List<object> GetAll(Type type)
        {
            IMapper mapper = GetMapper(type);
            return mapper.GetAll();
        }
        
        public bool Put(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Helper Methods

        private IMapper GetMapper(Type type)
        {
            if (type == typeof(Customer))
            {
                return new CustomersMapper(conn);
            }
            throw new NotSupportedException();
        }

        private static DBFacade GenerateInstance()
        {
            DBFacade res = new DBFacade();
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
            res.conn = new SqlConnection(connectionString);
            return res;
        }

        #endregion
    }
}
