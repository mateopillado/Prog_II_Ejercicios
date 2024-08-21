using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1._3.Clases
{
    internal class Pack : Producto
    {
		private int cantidad;

        public Pack(int cantidad, int codigo, string nombre, double precio) : base(codigo, nombre, precio)
        {
			Cantidad = cantidad;
        }

        public int Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}

		public override double CalcularPrecio() 
		{
			return cantidad * Precio; 
		}
    }
}
