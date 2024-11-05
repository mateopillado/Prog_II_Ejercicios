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


        public override string ToString()
        {
            return $"Factura Nro = {IdFactura}, Cantidad del producto = {Cantidad},Precio Vendido = {Precio},Articulo Vendido = {Articulo_.Nombre}";
        }



    }
}
