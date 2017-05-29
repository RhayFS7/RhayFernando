using Persistence.DAL.Registers;
using RhayFernando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Registers
{
    public class ProductServices
    {
        private ProductDAL productDAL = new ProductDAL();

        public IQueryable GetProductsClassifiedByName()
        {
            return productDAL.GetProductsClassifiedByName();

        }

       
        public Product GetProductById(long id)
        {
            return productDAL.GetProductById(id);
        }

        public void SaveProduct(Product product)
        {
            productDAL.SaveProduct(product);
        }

        public Product RemoveProductById(long id)
        {
            return productDAL.RemoveProductBy(id);
        }
    }
}
