using System.Collections.Generic;

namespace RhayFernando.Models
{
    public class Supplier
    {
        public long? SupplierID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}