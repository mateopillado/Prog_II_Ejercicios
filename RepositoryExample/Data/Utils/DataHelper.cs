﻿

using RepositoryExample.Data.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace RepositoryExample.Data
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _connection;
        private string cnnString = @"Data Source=MATEO;Initial Catalog=db_almacen;Integrated Security=True";

        private DataHelper()
        {
            _connection =  new SqlConnection (cnnString);
        }

        public static DataHelper GetInstance()
        {
            if (_instancia == null)
                _instancia = new DataHelper();

            return _instancia;
        }

        public SqlConnection GetConnection() 
        {
            return _connection;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            try
            {              
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch(SqlException)
            {
                t = null;
            }
            finally
            {
                _connection.Close();
            }
          
            return t;
        }


        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if(parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }


    }
}
