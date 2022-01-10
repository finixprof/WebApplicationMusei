using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Controllers
{
    public class CittaController : Controller
    {
        private static List<Citta> citta = new List<Citta>
        {
            new Citta
            {
                Id = 1,
                NazioneId = 1,
                Nome = "Roma"
            },
            new Citta
            {
                Id = 2,
                NazioneId = 1,
                Nome = "Milano"
            },
            new Citta
            {
                Id = 3,
                NazioneId = 1,
                Nome = "Reggio Emilia"
            },
            new Citta
            {
                Id = 4,
                NazioneId = 2,
                Nome = "Barcellona"
            },
            new Citta
            {
                Id = 5,
                NazioneId = 2,
                Nome = "Madrid"
            },

        };


        // GET: CittaController
        public ActionResult Index()
        {
            var model = citta; 
            return View(model);
        }

        // GET: CittaController/Details/5
        public ActionResult Details(int id)
        {
            var model = citta.Where(t => t.Id == id).FirstOrDefault();
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
