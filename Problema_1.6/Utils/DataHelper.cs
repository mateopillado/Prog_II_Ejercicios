using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._6.Utils
{
    public class DataHelper
    {

        private string cadenaConexion = @"Data Source=172.16.10.196;Initial Catalog=BancoDb;User ID=alumno1w2; Password=alumno1w2";

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
            finally { _connection.Close(); }

            return dt;
        }

        public bool ExecuteSPQuery(SqlCommand command)
        {
            try
            {
                _connection.Open();
                command.Connection = _connection;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                _connection.Close();
            }
        }



    }
}
