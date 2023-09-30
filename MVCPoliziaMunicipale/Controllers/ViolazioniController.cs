using MVCPoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPoliziaMunicipale.Controllers
{
    public class ViolazioniController : Controller
    {
        // GET: Violazioni
        public ActionResult Index()
        {
            List<Violazioni>violazioni = DB.ListaViolazioni();
            return View(violazioni);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Violazioni violazioni) 
        {
            if (ModelState.IsValid)
            {
                DB.CreaViolazione(violazioni);
                return RedirectToAction("Index");
            }
            else { return View("Error"); }
        }
    }
}