using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ybs_order_processing_system.Models;

namespace ybs_order_processing_system.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly YourOwnContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _context = new YourOwnContext(configuration);
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Buyers()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Sellers()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Products()
        {
            return View();
        }

        public JsonResult GetOrders()
        {
            var orders = _context.Orders.ToList();
            List<OrderJson> jsonOrders = new List<OrderJson>();
            
            foreach (Order o in orders)
            {
                o.Product = _context.Products.SingleOrDefault(x => x.ProductId == o.ProductId);
                o.Buyer = _context.Buyers.SingleOrDefault(x => x.BuyerId == o.BuyerId);
                o.Seller = _context.Sellers.SingleOrDefault(x => x.SellerId == o.SellerId);
                
                OrderJson newProduct = new OrderJson();
                newProduct.OrderId = o.OrderId;
                newProduct.OrderNum = o.OrderNum;
                newProduct.Buyer = o.Buyer.BuyerName;
                newProduct.Seller = o.Seller.SellerName;
                newProduct.Product = o.Product.ProductName;
                newProduct.OrderDate = o.OrderDate;
                newProduct.OrderStatus = o.OrderStatus;
                newProduct.OrderArrivalDate = o.OrderArrivalDate;
                newProduct.OrderPaymentType = o.OrderPaymentType;
                newProduct.ProductQuantity = o.ProductQuantity;
                newProduct.ShippingPrice = o.ShippingPrice;
                newProduct.BilledPrice = o.BilledPrice;
                newProduct.BuyerPhoneNum = o.BuyerPhoneNum;
                newProduct.BuyerAddress = o.BuyerAddress;
                
                jsonOrders.Add(newProduct);
            }
            
            return Json(jsonOrders);
        }
        
        public JsonResult GetBuyers()
        {
            var buyers = _context.Buyers.ToList();
            return Json(buyers);
        }
        
        public JsonResult GetSellers()
        {
            var sellers = _context.Sellers.ToList();
            return Json(sellers);
        }
        
        public JsonResult GetProducts()
        {
            var products = _context.Products.ToList();
            
            List<ProductJson> jsonProducts = new List<ProductJson>();
            
            foreach (Product p in products)
            {
                ProductJson newProduct = new ProductJson();
                newProduct.ProductId = p.ProductId;
                newProduct.ProductName = p.ProductName;               
                newProduct.ProductPrice = p.ProductPrice; 
                p.ProductCategory = _context.Categories.SingleOrDefault(x => x.CategoryId == p.ProductCategoryId);
                newProduct.ProductCategory = p.ProductCategory.CategoryName;               
                jsonProducts.Add(newProduct);
            }
            
            return Json(jsonProducts);
        }

        public IActionResult RejectMe(int orderId)
        {
            Order order = _context.Orders.SingleOrDefault(x => x.OrderId == orderId);
            if (order != null)
            {
                order.OrderStatus = "Rejected";
                _context.SaveChanges();
            }

            return Content("Ok");
        }
        
        public IActionResult DeleteSeller(int sellerId)
        {
            Seller seller = _context.Sellers.SingleOrDefault(x => x.SellerId == sellerId);
            if (seller != null)
            {
                _context.Sellers.Remove(seller);
                _context.SaveChanges();
            }

            return Content("Ok");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
