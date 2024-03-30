﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shoes.Areas.Admin.Controllers
{
    public class DashboarController : Controller
    {
        [Area("Admin")]
        // GET: DashController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashController/Create
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

        // GET: DashController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashController/Edit/5
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

        // GET: DashController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashController/Delete/5
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
