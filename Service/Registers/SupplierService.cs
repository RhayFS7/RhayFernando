using Persistence.DAL.Registers;
using RhayFernando.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service.Registers
{
    public class SupplierServices
    {
        private SupplierDAL supplierDAL = new SupplierDAL();

        public IQueryable<Supplier> GetSuppliersClassifiedsByName()
        {
            return supplierDAL.GetSuppliersClassifiedsByName();
        }


        public Supplier GetSupplierById(long id)
        {
            return supplierDAL.GetSupplierById(id);
        }

        public void SaveSupplier(Supplier supplier)
        {
            supplierDAL.SaveSupplier(supplier);
        }

        public Supplier RemoveSupplierById(long id)
        {
            return supplierDAL.RemoveSuppliertBy(id);
        }
    }
}
