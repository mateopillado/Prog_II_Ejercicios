using clase2.Data;
using clase2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase2.Services
{
    public class ProductService
    {

        private IProductRepository _repository;

        public ProductService() 
        {
            _repository = new ProductRepositoryADO();
        }

        public List<Product> GetProducts() 
        {
            return _repository.GetAll();
        }

        //public Product GetProductByCodigo(int cod)
        //{
        //    return _repositorio.GetById(cod);
        //}

        //public bool SaveProduct(Product oProduct)
        //{
        //    return _repositorio.Save(oProduct);
        //}
        //public bool DeleteProduct(int cod)
        //{
        //    return _repositorio.Delete(cod);
        //}



    }
}
