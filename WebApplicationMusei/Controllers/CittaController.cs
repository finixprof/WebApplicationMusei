using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Helpers;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Controllers
{
    public class CittaController : Controller
    {
        


        // GET: CittaController
        public ActionResult Index()
        {
            var model = DatabaseHelper.GetAllCitta(); 
            return View(model);
        }

        // GET: CittaController/Details/5
        public ActionResult Details(int id)
        {
            var model = DatabaseHelper.GetCittaById(id);
            return View(model);
        }

        // GET: CittaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CittaController/Create
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

        // GET: CittaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CittaController/Edit/5
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

        // GET: CittaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CittaController/Delete/5
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
