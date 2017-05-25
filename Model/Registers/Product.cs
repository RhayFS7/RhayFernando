using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhayFernando.Models
{
    public class Product
    {
        [DisplayName("id")]
        public long? ProductId { get; set; }
        [StringLength(100, ErrorMessage = "The product name must be at least 10 characters",
            MinimumLength = 10)]
        [Required(ErrorMessage = "Enter product name")]
        public string Name { get; set; }
        [DisplayName("Registration date ")]
        [Required(ErrorMessage = "Please inform the product registration date ")]
        public DateTime? DateRegistration { get; set; }

        [DisplayName("Category")]
        public long? CategoryId { get; set; }
        [DisplayName("Supplier")]
        public long? SupplierId { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}