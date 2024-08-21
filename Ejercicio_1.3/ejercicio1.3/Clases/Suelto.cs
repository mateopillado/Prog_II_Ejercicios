using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1._3.Clases
{
    internal class Suelto : Producto
    {

		private double medida;

        public Suelto(double medida,int codigo, string nombre, double precio) : base(codigo, nombre, precio)
        {
			this.medida = medida;
        }

        public double Medida
		{
			get { return medida; }
			set { medida = value; }
		}

		public override double CalcularPrecio() { 
			return medida * Precio; 
		
		}	





	}
}
