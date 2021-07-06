using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ybs_order_processing_system.Models;

namespace ybs_order_processing_system.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly YourOwnContext _context;
        private readonly ILogger<AuthenticationController> _logger;


        public AuthenticationController(IConfiguration configuration, ILogger<AuthenticationController> logger)
        {
            _context = new YourOwnContext(configuration);
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<ActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User authenticatedUser = VerifyCredientials(user);

                if (authenticatedUser == null)
                {
                    ViewBag.Message = "Invalid username or password";
                }
                else
                {
                    _logger.LogInformation(authenticatedUser.Username);
                    _logger.LogInformation(authenticatedUser.Role);
                    
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, authenticatedUser.Username),
                        new Claim(ClaimTypes.Role, authenticatedUser.Role)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Message = "Unexpected invalid model state. Check your inputs.";
            }

            return View("Index");
        }

        private User VerifyCredientials(User user)
        {
            User u = _context.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (u == null)
            {
                return null; // no username exists
            }
            
            return u; // password is correct
        }
    }
}
