﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Controllers
{
    public class NazioniController : Controller
    {

        private static List<Nazione> nazioni = new List<Nazione>
            {
                new Nazione
                {
                    Id = 1,
                    Nome = "Italia"
                },
                new Nazione
                {
                    Id = 2,
                    Nome = "Spagna"
                }
            };


        // GET: NazioniController
        public ActionResult Index()
        {
            var model = nazioni;
            return View(model);
        }

        // GET: NazioniController/Details/5
        public ActionResult Details(int id)
        {
            var model = nazioni.Where(t => t.Id == id).FirstOrDefault();
            return View(model);
        }

        // GET: NazioniController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NazioniController/Create
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

        // GET: NazioniController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NazioniController/Edit/5
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

        // GET: NazioniController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NazioniController/Delete/5
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
