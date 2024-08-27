using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso1w3
{
    public class Pack : Producto //heredamos de la clase producto
    {
        public Pack(): base() //conector
        {
            Cantidad = 0;
        }

        public int Cantidad { get; set; }

        public override double CalcularPrecio()
        {
            return Precio * Cantidad; //precio hereda de producto
        }

      
    }
}
