using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ybs_order_processing_system.Models
{
    [Table("ORDERS")]
    public partial class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ORDER_ID")]
        public int OrderId { get; set; }
        
        [Column("ORDER_NUM")]
        public int OrderNum { get; set; }
        
        [Column("ORDER_DATE", TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column("ORDER_STATUS")]
        [StringLength(50)]
        public string OrderStatus { get; set; } = "Not placed";
        
        [Column("ORDER_ARRIVAL_DATE", TypeName = "date")]
        public DateTime OrderArrivalDate { get; set; }

        [Required]
        [Column("ORDER_PAYMENT_TYPE")]
        [StringLength(50)]
        public string OrderPaymentType { get; set; }
        
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }
        
        [Column("PRODUCT_QUANTITY")]
        public int ProductQuantity { get; set; }
        
        [Column("BUYER_ID")]
        public int BuyerId { get; set; }
        
        [Required]
        [Column("BUYER_ADDRESS")]
        public string BuyerAddress { get; set; }
        
        [Required]
        [Column("BUYER_PHONE_NUM")]
        [StringLength(50)]
        public string BuyerPhoneNum { get; set; }
        
        [Column("SELLER_ID")]
        public int SellerId { get; set; }
        
        [Column("SHIPPING_PRICE")]
        public double ShippingPrice { get; set; }
        
        [Column("BILLED_PRICE")]
        public double BilledPrice { get; set; }

        [ForeignKey(nameof(BuyerId))]
        [InverseProperty("Orders")]
        public virtual Buyer Buyer { get; set; }
        
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Orders")]
        public virtual Product Product { get; set; }
        
        [ForeignKey(nameof(SellerId))]
        [InverseProperty("Orders")]
        public virtual Seller Seller { get; set; }
    }
}
