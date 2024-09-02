using Problema_1._6.Domain;
using Problema_1._6.Repositories.Contracts;
using Problema_1._6.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._6.Repositories.Implementations
{
    internal class CuentaRepository : ICuentaRepository
    {
        public List<Cuenta> GetAll()
        { 
            List<Cuenta> list = new List<Cuenta>();
            //traer cuentas
            var dt = DataHelper.GetInstance().ExecuteSPQuery("obtener_cuentas");
            //mapeo
            foreach (DataRow row in dt.Rows)
            {
                Cuenta c = new Cuenta();
                c.Id = (int)row[0];
                c.Cbu = row[1].ToString();
                c.Saldo = (decimal) row[2];
                c.Ultimo_Movimiento = (DateTime)row["ULTIMO_MOVIMIENTO"];

                Tipo_Cuenta tp = new Tipo_Cuenta();
                tp.Id = (int)row["tipo_cuenta_id"];
                tp.Nombre = row["Nombre_Cuenta"].ToString();

                c.Tipo_Cuenta = tp;
                c.Cliente = (int)row["Cliente_id"];

                list.Add(c);
            }

            return list;
            
        }
    }
}
