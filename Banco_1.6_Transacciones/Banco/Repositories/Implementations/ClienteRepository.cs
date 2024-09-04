using Banco.Entities;
using Banco.Repositories.Contracts;
using Banco.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        //public List<Cliente> GetAll()
        //{
        //    var clientes = new List<Cliente>();
        //    DataTable table = DataHelper
        //        .GetInstance()
        //        .ExecuteSPQuery("OBTENER_CLIENTES", null);

        //    if (table != null)
        //    {
        //        foreach (DataRow row in table.Rows)
        //        {
        //            Cliente cliente = new Cliente();
        //            {
        //                Id = Convert.ToInt32(row["Id"]),
        //                Nombre = row["Nombre"].ToString(),
        //                Apellido = row["Apellido"].ToString(),
        //                Dni = row["Dni"].ToString()
        //            };
        //            clientes.Add(cliente);
        //        }
        //    }

        //    return clientes;
        //}

       

        //public bool Add(Cliente cliente)
        //{
        //    var parametros = new List<ParameterSQL>
        //    {
        //        new ParameterSQL("@Nombre", cliente.Nombre),
        //        new ParameterSQL("@Apellido", cliente.Apellido),
        //        new ParameterSQL("@Dni", cliente.Dni)
        //    };

        //    int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("CREAR_CLIENTE", parametros);
        //    return filasAfectadas > 0;
        //}

        public bool Add(Cliente cliente)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction transaction = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConeccion();
                cnn.Open();
                transaction = cnn.BeginTransaction();

                var cmd = new SqlCommand("CREAR_CLIENTE", cnn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NOMBRE", cliente.Nombre);
                cmd.Parameters.AddWithValue("APELLIDO", cliente.Apellido);
                cmd.Parameters.AddWithValue("DNI", cliente.Dni);

                SqlParameter param = new SqlParameter("id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();  

                int clienteID = (int) param.Value;

                foreach (var cuenta in cliente.Cuentas)
                {
                    var cmdCuenta = new SqlCommand("CREAR_CUENTA", cnn, transaction);
                    cmdCuenta.CommandType = CommandType.StoredProcedure;
                    cmdCuenta.Parameters.AddWithValue("@CBU", cuenta.Cbu);
                    cmdCuenta.Parameters.AddWithValue("@SALDO", cuenta.Saldo);
                    cmdCuenta.Parameters.AddWithValue("@TIPO_CUENTA_ID",cuenta.TipoCuenta.Id);
                    cmdCuenta.Parameters.AddWithValue("@ULTIMO_MOVIMIENTO", cuenta.UltimoMovimiento);
                    cmdCuenta.Parameters.AddWithValue("@CLIENTE_ID", clienteID);
                    cmdCuenta.ExecuteNonQuery();
                }

                transaction.Commit();

            }
            catch (SqlException)
            {
                result = false;
                if (transaction != null)
                    transaction.Rollback();
            }
            finally  
            { 
                if (cnn != null && cnn.State == ConnectionState.Open) { 
                    cnn.Close(); 
                }
            }
 
            return result;
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
