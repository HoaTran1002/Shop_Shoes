using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoes.Areas.Admin.Models;
using WebMatrix.WebData;


namespace Shoes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ManageShopDbContext _context;
        public AccountController(ManageShopDbContext context)
        {
            _context = context;
        }
        //GET:/Account/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HandelLogin(Login infor, string returnUrl)
        {
            
            return View();
        }
    }
}
