using Problema_1._5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Repositories.Contracs
{
    public interface IFormaPagoRepository
    {

        List<FormaPago> GetAll();

        bool Add(FormaPago formaPago);

        bool Delete(int idFormaPago);
    }
}
