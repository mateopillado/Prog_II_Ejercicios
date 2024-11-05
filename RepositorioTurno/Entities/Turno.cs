using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Entities
{
    public class Turno
    {
        public int Id { get; set; }

        public string Fecha { get; set; }

        public string Hora { get; set; }

        public string cliente { get; set; }

        public List<DetalleTurno> lstDetalles { get; set; }

        public Turno()
        {
            lstDetalles = new List<DetalleTurno>();
        }

    }
}
