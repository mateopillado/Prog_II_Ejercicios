using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Entities
{
    public class Servicio
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Costo { get; set; }

        public string EnPromocion { get; set; }

    }
}


//pasos para el proyecto

//1) crear el proyecto
//2) Dll libreria de clases
//3)entities
//4) singleton -> datahelper 
//5) repository -> implementacioones y contratos 
//6) service -> implementaciones e interfaces
//7) crear proyecto (web api)
//8) indicar dependencias entre proyectos, la api depende de la libreria de clase
//9) controlador/end points
//10) configurar que proyecto ejecuta primero (API)