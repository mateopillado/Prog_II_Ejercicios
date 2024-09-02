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
    internal class TipoCuentaRepository : ITipoCuentaRepository
    {
        public List<Tipo_Cuenta> GetAll()
        {
            List<Tipo_Cuenta> list = new List<Tipo_Cuenta>();

            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("obtener_tipos_cuentas");

            foreach (DataRow row in dt.Rows)
            {
                Tipo_Cuenta tp = new Tipo_Cuenta();
                tp.Id = (int)row[0];
                tp.Nombre = row[1].ToString();
                list.Add(tp);
            }

            return list;
        }
    }
}
