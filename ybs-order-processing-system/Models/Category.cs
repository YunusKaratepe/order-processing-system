using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ybs_order_processing_system.Models
{
    [Table("CATEGORY")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }
        [Required]
        [Column("CATEGORY_NAME")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.ProductCategory))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
