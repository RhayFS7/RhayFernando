using Persistence.Contexts;
using RhayFernando.Models;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Registers
{
    public class SupplierDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Supplier> GetSuppliersClassifiedsByName()
        {
            return context.Suppliers.OrderBy(b => b.Name);
        }

        public void SaveSupplier(Supplier supplier)

        {

            if (supplier.SupplierID == null)
            {
                context.Suppliers.Add(supplier);
            }
            else
            {
                context.Entry(supplier).State = EntityState.Modified;
            }

            context.SaveChanges();

        }

        public Supplier RemoveSuppliertBy(long id)

        {
            Supplier supplier = GetSupplierById(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return supplier;

        }

        public Supplier GetSupplierById(long id)
        {
            return context.Suppliers.Where(s => s.SupplierID == id).First();
        }

    }
}


