using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ybs_order_processing_system.Models;

namespace ybs_order_processing_system.Controllers
{
	public class OrderController : Controller
	{
		
		private readonly YourOwnContext _context;
		private readonly ILogger<OrderController> _logger;

        
		public OrderController(IConfiguration configuration, ILogger<OrderController> logger)
		{
			_context = new YourOwnContext(configuration);
			_logger = logger;
		}

		private void GetLists()
		{
			ViewData["Buyers"] = _context.Buyers.Select(x => new SelectListItem { Text = x.BuyerName, Value = x.BuyerId.ToString() }).ToList();
			ViewData["Products"] = _context.Products.Select(x => new SelectListItem { Text = x.ProductName + " - " + x.ProductPrice + " TL", Value = x.ProductId.ToString() }).ToList();
			ViewData["Sellers"] = _context.Sellers.Select(x => new SelectListItem { Text = x.SellerName, Value = x.SellerId.ToString() }).ToList();
		}
		
		[HttpGet]
		public IActionResult PlaceOrder()
		{
			GetLists();
			return View();
		}

		[HttpPost]
		public IActionResult CreateOrder(Order order)
		{
			GetLists();
			if (!ModelState.IsValid)
			{
				ViewBag.PlaceStatus = false;
				ViewBag.Message = "Invalid inputs. Try again.";
				return View("PlaceOrder");
			}

			Random random = new Random();
			order.OrderNum = random.Next(1000000, 9999999); // TODO check uniqueness
			
			DateTime today = DateTime.Today;
			order.OrderDate = today;

			order.OrderArrivalDate = today.AddDays(10);

			order.Product = _context.Products.SingleOrDefault(x => x.ProductId == order.ProductId);

			double quantityPrice = order.ProductQuantity * order.Product.ProductPrice;
			
			order.BilledPrice = Math.Round(order.ShippingPrice + quantityPrice);

			order.OrderStatus = "Placed";

			order.Buyer = _context.Buyers.SingleOrDefault(x => x.BuyerId == order.BuyerId);

			_context.Orders.Add(order);
			_context.SaveChanges();
			_logger.LogInformation("Added order");

			ViewBag.PlaceStatus = true;
			ViewBag.Message = "Order has been placed! You can close this page.";
			ViewBag.Order = order;

			GetLists();
			return View("PlaceOrder");
		}
	}

}