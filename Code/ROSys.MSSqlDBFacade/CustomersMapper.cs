using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.MSSqlDBFacade
{
    public class CustomersMapper : Contracts.IMapper
    {
        private const string TABLE_NAME = "Customer";
        private SqlConnection conn = null;
        internal CustomersMapper(SqlConnection conn)
        {
            this.conn = conn;
        }

        #region Interface Implementation

        public object Get(Guid id)
        {
            string query = string.Format("SELECT * FROM {0} WHERE Id = '{1}'", TABLE_NAME, id.ToString());
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    bool res = rdr.Read();
                    return res ? DataReaderToCustomer(rdr):null;
                }
            }
        }

        public List<object> GetAll()
        {
            string query = string.Format("SELECT * FROM {0}", TABLE_NAME);
            List<object> res = new List<object>();
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    res.Add(DataReaderToCustomer(rdr));
            return res;
        }

        public bool Put(object obj)
        {
            try
            {
                Customer cus = (Customer)obj;

                //todo:Check for SQL Injection!
                string query = string.Format("INSERT INTO {0} (Id,FirstName,LastName) VALUES('{1}','{2}','{3}');", TABLE_NAME, cus.Id .ToString() ,cus.FirstName, cus.LastName);
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                    return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }
        #endregion

        #region Helper Methods
        private Customer DataReaderToCustomer(SqlDataReader rdr)
        {
            if (rdr == null) return null;
            Customer res = new Customer();
            res.Id = new Guid(rdr["Id"].ToString());
            res.FirstName = rdr["FirstName"].ToString();
            res.LastName = rdr["LastName"].ToString();
            return res;
        }
        #endregion
    }
}
