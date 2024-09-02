using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._6.Domain
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Cbu { get; set; }

        public decimal Saldo { get; set; }

        public DateTime Ultimo_Movimiento { get; set; }

        public Tipo_Cuenta Tipo_Cuenta { get; set; }

        public int Cliente { get; set; }

    }
}
