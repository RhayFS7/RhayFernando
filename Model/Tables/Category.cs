using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhayFernando.Models
{
    public class Category
    {
        public long? CategoryID { get; set; }
        public string Name { get; set; }
        [NotMapped]

        public virtual ICollection<Product> Products { get; set; }
    }
}