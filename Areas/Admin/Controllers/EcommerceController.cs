using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using Shoes.Areas.Admin.Models;
using System;
using System.IO;

namespace Shoes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EcommerceController : Controller
    {
        private readonly ManageShopDbContext _context;

        [BindProperty]
        public IFormFile FileUpload { get; set; }
        public EcommerceController(ManageShopDbContext context)
        {
            _context = context;
        }

  
        // GET: EcommerceController
        public IActionResult Index()
        {
            return View();
        }

      
        // GET: EcommerceController/CategoryProduct
        public async Task<IActionResult> CategoryProduct()
        {
            var test = await _context.Product.ToListAsync();

            ViewBag.listProduct = test;
            return View(test);
        }

        // POST: EcommerceController/DeleteProduct
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            Product pr = _context.Product.Single(a => a.MASP == id);

            //bắt đầu xoá file trong hệ thống
            string filename = pr.HINHANH;
            filename = Path.GetFileName(filename);
            string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Assets\\Admin\\Files", filename);

           
            FileInfo myfileinf = new FileInfo(uploadfilepath);
            myfileinf.Delete();


            //kết thuc xoá file trong hệ thống

            // xoá file trong database
            _context.Remove( _context.Product.Single(a => a.MASP == id));
            _context.SaveChanges();
            
            return Redirect("CategoryProduct");
            //return RedirectToAction("Index", "Home");
        }

        
        // GET: EcommerceController/AddProduct
        public IActionResult AddProduct()
        {
            return View();
        }
        // POST: EcommerceController/AddProduct
        [HttpPost]
        public async Task<IActionResult> HandelAddProduct(Product pr, IFormFile fileImage)
        {
            string filename = fileImage.FileName;
            filename = Path.GetFileName(filename);
            string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Assets\\Admin\\Files", filename);
            var stream = new FileStream(uploadfilepath, FileMode.Create);
            fileImage.CopyToAsync(stream);
            
            pr.NGAYTHEM = DateTime.Now;
            pr.HINHANH = filename;

            _context.Product.Add(pr);
            _context.SaveChanges();
            return Redirect("CategoryProduct");

            

        }




        // GET: EcommerceController/EditProduct
        public IActionResult EditProduct(int id)
        {
            Product product = _context.Product.Single(a => a.MASP == id);
            ViewBag.product = product;
            return View();
        }
        // POST: EcommerceController/HandelEditProduct
        [HttpPost]
        public IActionResult HandelEditProduct(int id ,Product product)
        {
            var pr = _context.Product.First(a => a.MASP == id);
            pr.TENSP = product.TENSP;
            pr.MOTA = product.MOTA;
            pr.HINHANH = product.HINHANH;
            pr.GIA = product.GIA;
            pr.KICHTHUOC = product.KICHTHUOC;
            pr.SOLUONG = product.SOLUONG;
            pr.MAMAU = product.MAMAU;
            pr.MALOAI = product.MALOAI;
            pr.NGAYSUA = DateTime.Now;
            _context.SaveChanges();
            return Redirect("CategoryProduct");
           

        }










        // GET: EcommerceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EcommerceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EcommerceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EcommerceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EcommerceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EcommerceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EcommerceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
