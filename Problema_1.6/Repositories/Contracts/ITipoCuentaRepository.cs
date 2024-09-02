using Problema_1._6.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._6.Repositories.Contracts
{
    internal interface ITipoCuentaRepository
    {

        List<Tipo_Cuenta> GetAll();

        

    }
}
