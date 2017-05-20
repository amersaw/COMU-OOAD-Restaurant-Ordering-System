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
        
        public DBFacade()
        {
            //DBFacade res = new DBFacade();
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

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
            IMapper mapper = GetMapper(obj.GetType());
            return mapper.Put(obj);
        }

        #endregion
        
        #region Helper Methods

        private IMapper GetMapper(Type type)
        {
            if (type == typeof(Customer))
                return new CustomersMapper(conn);

            else if (type == typeof(FoodDescription))
                return new FoodDescriptionMapper(conn);

            throw new NotSupportedException();
        }
        
        #endregion
    }
}
