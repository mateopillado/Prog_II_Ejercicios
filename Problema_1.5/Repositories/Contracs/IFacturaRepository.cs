﻿using Problema_1._5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Repositories.Contracs
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();

        bool Add(Factura fact);

        bool Delete(int nroFactura);

        List<DetalleFactura> GetById(int nroFactura);
        
    }
}
