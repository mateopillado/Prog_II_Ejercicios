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
            List<Product> products = new List<Product>();





            return products;
        }





    }
}
