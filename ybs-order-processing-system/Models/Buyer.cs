using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ybs_order_processing_system.Models
{
    [Table("BUYER")]
    public partial class Buyer
    {
        public Buyer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("BUYER_ID")]
        public int BuyerId { get; set; }
        [Required]
        [Column("BUYER_NAME")]
        [StringLength(50)]
        public string BuyerName { get; set; }
        [Required]
        [Column("BUYER_MAIL")]
        [StringLength(50)]
        public string BuyerMail { get; set; }

        [InverseProperty(nameof(Order.Buyer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
