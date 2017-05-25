using Persistence.Contexts;
using RhayFernando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Persistence.DAL.Registers
{
    public class ProductDAL
    {
        private EFContext context = new EFContext();
        public IQueryable GetProductsClassifiedByName()

        {

            return context.Products.Include(c => c.Category).
            Include(s => s.Supplier).OrderBy(n => n.Name);

        }

        public Product GetProductById(long id)

        {

            return context.Products.Where(p => p.ProductId == id).
            Include(c => c.Category).Include(s => s.Supplier).First();

        }

        public void SaveProduct(Product product)

        {

            if (product.ProductId == null)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
            }

            context.SaveChanges();

        }

        public Product RemoveProductBy(long id)

        {
            Product product = GetProductById(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;

        }

    }
}

