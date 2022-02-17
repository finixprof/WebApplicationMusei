using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Helpers;
using WebApplicationMusei.Models.Entities;
using WebApplicationMusei.Models.Views;

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
            var model = new CittaViewModel();
            model.Nazioni = DatabaseHelper.GetAllNazione();

            return View(model);
        }

        // POST: CittaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Citta model)
        {
            try
            {
                if (!ModelState.IsValid || model.NazioneId < 1)
                {
                    var msgKo = "Completa tutti i campi nella maniera corretta<br>";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    var msgKoAggregate = errors.Select(t => t.ErrorMessage).Aggregate((x, y) => $"{x}<br>{y}");
                    ViewData["MsgKo"] = msgKo + msgKoAggregate;
                    var viewModel = new CittaViewModel(model, DatabaseHelper.GetAllNazione());
                    return View(viewModel);
                }
                DatabaseHelper.SaveCitta(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                ViewData["MsgKo"] = "Errore, inserimento non riuscito";
                var viewModel = new CittaViewModel(model, DatabaseHelper.GetAllNazione());
                return View(viewModel);
            }
        }

        // GET: CittaController/Edit/5
        public ActionResult Edit(int id)
        {
            var citta = DatabaseHelper.GetCittaById(id);
            var model = new CittaViewModel();
            model.Nazioni = DatabaseHelper.GetAllNazione();
            model.Id = citta.Id;
            model.Nome = citta.Nome;
            model.NazioneId = citta.NazioneId;
            return View(model);
        }

        // POST: CittaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Citta model)
        {
            try
            {
                if (!ModelState.IsValid || model.NazioneId < 1)
                {
                    var msgKo = "Completa tutti i campi nella maniera corretta<br>";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    //foreach (var error in errors)
                    //{
                    //    msgKo += error.ErrorMessage + "<br>";
                    //}
                    var msgKoAggregate = errors.Select(t => t.ErrorMessage).Aggregate((x, y) => $"{x}<br>{y}");
                    ViewData["MsgKo"] = msgKo + msgKoAggregate;

                }
                else
                {
                    DatabaseHelper.SaveCitta(model);
                    //inseriamo messaggio update completato
                    ViewData["MsgOk"] = "Aggiornamento avvenuto con successo";

                }
            }
            catch
            {
                //inseriamo un eventuale errore
                ViewData["MsgKo"] = "Si è verificato un problema durante l'aggiornamento!";
            }
            var viewModel = new CittaViewModel(model, DatabaseHelper.GetAllNazione());
            return View(viewModel);
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


        public IActionResult Excel()
        {
            var citta = DatabaseHelper.GetAllCitta();
            try
            {
                var content = ExcelHelper.CreateExcelCittaList(citta);
                //facciamo dello stream
                var contentType = "application/octet-stream";

                //creo la response come file
                var fileName = $"citta_{DateTime.Now.ToShortDateString().Replace("/", "_")}.xlsx";
                return File(content, contentType, fileName);

            }
            catch (Exception ex)
            {
                ViewData["MsgKo"] = ex.Message;
            }
            return View();

        }
    }
}
