using Problema_1._5.Domain;
using Problema_1._5.Repositories.Contracs;
using Problema_1._5.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Repositories.Implementations
{
    internal class ArticuloRepository : IArticuloRepository
    {
        public bool Delete(int idArticulo)
        {
            bool result = false;

            var lst = new List<Parameter>
            {
                new Parameter("@cod_art", idArticulo)
            };

            result = DataHelper.GetInstance().ExecuteSPDML("sp_delete_articulos", lst) == 1;

            return result;
        }

        public List<Articulo> GetAll()
        {
            var lst = new List<Articulo>();

            var dt = DataHelper.GetInstance().ExecuteSPQuery("sp_consult_art", null);

            foreach (DataRow dr in dt.Rows)
            {
                var articulo = new Articulo
                {
                    Id = (int )dr["COD_ARTICULO"],
                    Nombre = (string) dr["NOMBRE"],
                    Precio = (decimal) dr["PRECIO"]
                };
                lst.Add(articulo);
            }

            return lst;
        }

        public bool Save(Articulo articulo)
        {
            //new ParameterSQL("@Nombre", cliente.Nombre),

            var lst = new List<Parameter>
            {
                new Parameter("@nombre", articulo.Nombre),
                new Parameter("@pre_unitario", articulo.Precio)
            };

            int result = DataHelper.GetInstance().ExecuteSPDML("sp_insert_articulos", lst);

            return result == 1;
        }
    }
}
