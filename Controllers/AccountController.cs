using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoes.Areas.Admin.Models;
using Shoes.Models;
using System.Security.Claims;

namespace Shoes.Controllers
{
	public class AccountController : Controller
	{
        public IActionResult Login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;//checked if the user is already logged in
            if (claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login modelLogin)
        {
            if (modelLogin.UserName == "usertest" && modelLogin.Password == "123")
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.UserName) ,
                    new Claim("OtherProperties", "Example Role")
                };
                //-------------------------------------------------------------------------
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                //-------------------------------------------------------------------------
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeeploggedIn,//auto display on form
                };
                //-------------------------------------------------------------------------
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }
            ViewData["ValidateMessage"] = "User Not Found";
            return View();
        }
        
		
        public ActionResult Register()
        {
            return View();
        }
    

        
		

		
		

		
	}
}
