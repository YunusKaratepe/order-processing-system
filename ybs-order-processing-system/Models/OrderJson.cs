using System;

namespace ybs_order_processing_system.Models
{
	public partial class OrderJson
	{
        public int OrderId { get; set; }
                
        public int OrderNum { get; set; }
        
        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = "Not placed";
        
        public DateTime OrderArrivalDate { get; set; }

        public string OrderPaymentType { get; set; }
        
        public string Product { get; set; }
        
        public int ProductQuantity { get; set; }
        
        public string Buyer { get; set; }
        
        public string BuyerAddress { get; set; }
        
        public string BuyerPhoneNum { get; set; }
        
        public string Seller { get; set; }
        
        public double ShippingPrice { get; set; }
        
        public double BilledPrice { get; set; }
    
	}
}