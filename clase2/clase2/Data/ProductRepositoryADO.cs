using clase2.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace clase2.Data
{
    internal class ProductRepositoryADO : IProductRepository
    {

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            //traer registros
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_Recuperar_Productos");
            //mapeo
            foreach (DataRow row in dt.Rows)
            {
                Product p = new Product();
                p.Codigo = (int)row[0];
                p.Nombre = row["n_producto"].ToString();
                p.Precio = (double)row["precio"];
                p.Stock = (int)row["stock"];
                p.Activo = (bool)row["esta_activo"];
                list.Add(p);
            }

            return list;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
