using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ybs_order_processing_system.Models
{
    [Table("SELLER")]
    public partial class Seller
    {
        public Seller()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("SELLER_ID")]
        public int SellerId { get; set; }
        [Required]
        [Column("SELLER_NAME")]
        [StringLength(50)]
        public string SellerName { get; set; }
        [Required]
        [Column("SELLER_PHONE_NUM")]
        [StringLength(50)]
        public string SellerPhoneNum { get; set; }
        [Required]
        [Column("SELLER_MAIL")]
        [StringLength(50)]
        public string SellerMail { get; set; }
        [Required]
        [Column("SELLER_ADDRESS")]
        [StringLength(50)]
        public string SellerAddress { get; set; }

        [InverseProperty(nameof(Order.Seller))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
