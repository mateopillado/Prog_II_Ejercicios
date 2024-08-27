using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso1w3
{
    public abstract class Producto : IPrecio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        //public double CalcularPrecio() //podriamos hacer que le metodo haga algo
        //{
        //    return Precio;
        //}

        public abstract double CalcularPrecio(); //podriamos decirle que no haga nada y convertir la clase en abstracta

        public override string ToString()
        {
            return Nombre;
        }
    }

}
