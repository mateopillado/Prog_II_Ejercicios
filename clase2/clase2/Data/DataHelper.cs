using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase2.Data
{
    public class DataHelper
    {

        private string cadenaConexion = @"Data Source=localhost;Initial Catalog=Almacen;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private static DataHelper _instance;
        private SqlConnection _connection;

        //aplicando el singleton
        private DataHelper()
        {
            _connection = new SqlConnection(cadenaConexion);
        }


        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException)
            {
                //gestion del error
                dt = null;
                throw;
            }
           
            return dt;
        }













    }
}
