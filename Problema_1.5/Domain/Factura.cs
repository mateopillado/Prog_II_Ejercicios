using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Domain
{
    public class Factura
    {

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public FormaPago FormaPago { get; set; }

        public int Cliente { get; set; }

        public List<DetalleFactura> DetalleList { get; set;} = new List<DetalleFactura>();

        public override string ToString()
        {
            return $"[{Id} {Cliente} {FormaPago.Nombre}]";
        }



    }
}
