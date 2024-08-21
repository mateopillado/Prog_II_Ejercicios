using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1._3.Clases
{
    abstract class Producto : IPrecio
    {
        private int codigo;
        private string nombre;
        private double precio;
      
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Producto(int codigo, string nombre, double precio)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Precio = precio;
        }


        public abstract double CalcularPrecio();
        
    }
}
