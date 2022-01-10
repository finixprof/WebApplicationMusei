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
    public class MuseiController : Controller
    {
                // GET: MuseiController
        public ActionResult Index()
        {
            var model = DatabaseHelper.GetAllMuseo();
            return View(model);
        }

        // GET: MuseiController/Details/5
        public ActionResult Details(int id)
        {
            var model = DatabaseHelper.GetMuseoById(id);
            return View(model);
        }

        // GET: MuseiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MuseiController/Create
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

        // GET: MuseiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MuseiController/Edit/5
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

        // GET: MuseiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MuseiController/Delete/5
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
