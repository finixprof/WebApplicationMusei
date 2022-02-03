using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Helpers;
using WebApplicationMusei.Models.Dtos;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Controllers
{
    public class NazioniController : Controller
    {



        // GET: NazioniController
        public ActionResult Index()
        {
            var model = DatabaseHelper.GetAllNazione();
            return View(model);
        }

        // GET: NazioniController/Details/5
        public ActionResult Details(int id)
        {
            var model = DatabaseHelper.GetNazioneById(id);
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
        public ActionResult Create(NazioneDto model) //IFormCollection collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var msgKo = "Completa tutti i campi nella maniera corretta<br>";
                    var errors = ModelState.Values.SelectMany(v => v.Errors); //recuperiamo la lista di errori
                    var msgKoAggregate = errors.Select(t => t.ErrorMessage).Aggregate((x, y) => $"{x}<br>{y}"); //concatena in una string gli errori
                    ViewData["MsgKo"] = msgKo + msgKoAggregate;
                    return View(model);
                }
                DatabaseHelper.SaveNazione(model);
                if (model.FileFlag != null)
                {
                    var path = PathHelper.GetPathNazione(model.Id);
                    if (!Directory.Exists(path))
                    {
                        //1)creazione cartella nazioni/id in uploads se non esiste con id quello del modello
                        Directory.CreateDirectory(path);
                    }
                    //2)salvare il contenuto di FileFlag nel percorso creato
                    model.ImgBandiera = Guid.NewGuid() + Path.GetExtension(model.FileFlag.FileName);
                    var filePath = path + "\\" + model.ImgBandiera;
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        try
                        {
                            model.FileFlag.CopyTo(fileStream);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    DatabaseHelper.SaveNazione(model);

                }
                return RedirectToAction(nameof(Index)); //redirect alla lista se non scatta un'eccezione
            }
            catch (Exception ex)
            {
                //ex.Message + ModelBinderAttribute dovranno essere passati alla view
                ViewData["MsgKo"] = ex.Message; //ex.message deve essere loggato e non inviato all'utente, customizzare il msg in Errore server riprova piu tardi
                return View(model);
            }
        }

        // GET: NazioniController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = DatabaseHelper.GetNazioneById(id);
            return View(model);
        }

        // POST: NazioniController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nazione model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var msgKo = "Completa tutti i campi nella maniera corretta<br>";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    //foreach (var error in errors)
                    //{
                    //    msgKo += error.ErrorMessage + "<br>";
                    //}
                    var msgKoAggregate = errors.Select(t => t.ErrorMessage).Aggregate((x, y) => $"{x}<br>{y}");
                    ViewData["MsgKo"] = msgKo + msgKoAggregate;
                    return View(model);
                }
                DatabaseHelper.SaveNazione(model);
                //inseriamo messaggio update completato
                ViewData["MsgOk"] = "Aggiornamento avvenuto con successo";
            }
            catch
            {
                //inseriamo un eventuale errore
                ViewData["MsgKo"] = "Si è verificato un problema durante l'aggiornamento!";
            }
            return View(model);
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
