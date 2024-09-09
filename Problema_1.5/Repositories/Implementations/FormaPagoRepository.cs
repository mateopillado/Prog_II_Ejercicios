using Problema_1._5.Repositories.Contracs;
using Problema_1._5.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problema_1._5.Domain;

namespace Problema_1._5.Repositories.Implementations
{
    public class FormaPagoRepository : IFormaPagoRepository
    {
        public bool Add(FormaPago formaPago)
        {
            var lst = new List<Parameter>
            {
                new Parameter("@forma_pago",formaPago.Nombre),
                new Parameter("@recargo", formaPago.Recargo)
            };

            return DataHelper.GetInstance().ExecuteSPDML("sp_insert_formaPago", lst) == 1;
        }

        public bool Delete(int idFormaPago)
        {
            throw new NotImplementedException();
        }

        public List<FormaPago> GetAll()
        {
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_Consult_formaPago", null);
            var lstFormas = new List<FormaPago>();

            foreach (DataRow dr in dt.Rows)
            {
                var oForma = new FormaPago
                {
                    Id = (int)dr["id_forma_pago"],
                    Nombre = (string) dr["forma_pago"],
                    Recargo = (decimal) dr["recargo"]
                };
                lstFormas.Add(oForma);
            }

            return lstFormas;
        }
    }
}
