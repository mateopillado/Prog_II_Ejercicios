using Problema_1._6.Domain;
using Problema_1._6.Repositories.Contracts;
using Problema_1._6.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._6.Repositories.Implementations
{
    internal class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            List<Cliente> list = new List<Cliente>();
            //traer registros
            var dt = DataHelper.GetInstance().ExecuteSPQuery("obtener_clientes");
            //mapeo
            foreach (DataRow row in dt.Rows)
            {
                Cliente c = new Cliente();
                c.Id = (int)row[0];
                c.Nombre = row[1].ToString();
                c.Apellido = row[2].ToString();
                c.Dni = row["DNI"].ToString();
                list.Add(c);
            }

            return list;
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Cliente oCliente)
        {
            SqlCommand command = new SqlCommand("crear_cliente");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@nombre", oCliente.Nombre));
            command.Parameters.Add(new SqlParameter("@apellido", oCliente.Apellido));
            command.Parameters.Add(new SqlParameter("@dni", oCliente.Dni));

            DataHelper.GetInstance().ExecuteSPQuery(command);

            return true;
        }
    }
}
