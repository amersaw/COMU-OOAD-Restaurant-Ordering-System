using ROSys.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ROSys.Model;

namespace ROSys.MSSqlDBFacade
{
    class FoodDescriptionMapper : IMapper
    {
        private SqlConnection conn;
        private const string TABLE_NAME = "FoodDescription";

        public FoodDescriptionMapper(SqlConnection conn)
        {
            this.conn = conn;
        }

        public object Get(Guid id)
        {

            string query = string.Format("SELECT * FROM {0} WHERE Id = '{1}'", TABLE_NAME, id.ToString());
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    bool res = rdr.Read();
                    return res ? DataReaderToFoodDescription(rdr) : null;
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
                    res.Add(DataReaderToFoodDescription(rdr));
            return res;
        }

        public bool Put(object obj)
        {
            throw new NotImplementedException();
        }

        #region Helper Methods
        private FoodDescription DataReaderToFoodDescription(SqlDataReader rdr)
        {
            if (rdr == null) return null;
            FoodDescription res = new FoodDescription();
            res.Id = new Guid(rdr["Id"].ToString());
            res.Name = rdr["Name"].ToString();
            res.Description = rdr["Description"].ToString();
            res.Category = rdr["Category"].ToString();
            res.Price = decimal.Parse(rdr["Price"].ToString());
            res.Quantity = double.Parse(rdr["Quantity"].ToString());
            res.QuantityUnit = (QuantityUnit)int.Parse(rdr["QuantityUnit"].ToString());
            return res;
        }
        #endregion
    }
}
