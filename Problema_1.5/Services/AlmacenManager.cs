using Problema_1._5.Domain;
using Problema_1._5.Repositories.Contracs;
using Problema_1._5.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Services
{
    public class AlmacenManager
    {

        IFormaPagoRepository _formaPagoRepository;
        IArticuloRepository _articuloRepository;
        IFacturaRepository _facturaRepository;

        public AlmacenManager()
        {
            _formaPagoRepository = new FormaPagoRepository();
            _articuloRepository = new ArticuloRepository();
            _facturaRepository = new FacturaRepository();
        }

        public List<FormaPago> GetAllFormaPago()
        {
            return _formaPagoRepository.GetAll();
        }

        public List<Articulo> GetAllProductos()
        {
            return _articuloRepository.GetAll();
        }


        public List<Factura> GetAllFacturas()
        {
            return _facturaRepository.GetAll();
        }


        public bool InsertArticulo(Articulo art)
        {
            return _articuloRepository.Save(art);
        }


        public bool InsertFactura(Factura fac)
        {
            return _facturaRepository.Add(fac);
        }

        public bool DeleteArticulo(int idArticulo)
        {
            return _articuloRepository.Delete(idArticulo);
        }


        public bool AddFormaPago (FormaPago forma)
        {
            return _formaPagoRepository.Add(forma);
        }

        public List<DetalleFactura> GetFacturaById(int id)
        {
            return _facturaRepository.GetById(id);
        }

    }
}
