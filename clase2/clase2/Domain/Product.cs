using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase2.Domain
{
    public class Product
    {

		public int Codigo { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; }


        //override del tostring

	}
}
