using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ybs_order_processing_system.Models
{
    [Table("PRODUCT")]
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }
        [Required]
        [Column("PRODUCT_NAME")]
        public string ProductName { get; set; }
        [Column("PRODUCT_PRICE")]
        public double ProductPrice { get; set; }
        [Column("PRODUCT_CATEGORY_ID")]
        public int ProductCategoryId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        [InverseProperty(nameof(Category.Products))]
        public virtual Category ProductCategory { get; set; }
        [InverseProperty(nameof(Order.Product))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
