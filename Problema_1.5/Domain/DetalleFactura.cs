using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Domain
{
    public class DetalleFactura
    {

        public int Id { get; set; }
        public Articulo Articulo_ { get; set; }

        public int  Cantidad { get; set; }

        public decimal Precio { get; set; }

        public int IdFactura { get; set; }






    }
}
