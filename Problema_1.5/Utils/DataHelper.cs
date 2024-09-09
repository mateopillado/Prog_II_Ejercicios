using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Utils
{
    public class DataHelper
    {


        private SqlConnection _connection;
        private static DataHelper _instance;
        private string cnnString = @"Data Source=MATEO;Initial Catalog=COMERCIO_transacciones;Integrated Security=True;";

        private DataHelper()
        {
            _connection = new SqlConnection(cnnString);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }


        public SqlConnection GetConnection()
        {
            return _connection;
        }


        public DataTable ExecuteSPQuery(string sp, List<Parameter>? parameters)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (Parameter param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.name, param.value);
                    }
                }

                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            {
                dt = null;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return dt;
        }


        public int ExecuteSPDML(string sp, List<Parameter>? parameters)
        {
            int filas;
            SqlCommand cmd;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (Parameter param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.name, param.value);
                    }
                }

                filas = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                filas = 0;
            }
            finally 
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }





            return filas;
        }


    }
}
