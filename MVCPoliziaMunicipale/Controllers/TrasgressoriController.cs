using MVCPoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPoliziaMunicipale.Controllers
{
    public class TrasgressoriController : Controller
    {
        // GET: Tragressori
        public ActionResult Index()
        {
            List<Trasgressore>trasgressori = DB.ListaTrasgressori();
            return View(trasgressori);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Trasgressore tr)
        {
            if (ModelState.IsValid)
            {
                DB.CreaTrasgressore(tr);
                return RedirectToAction("Index");
            }
            else { return View("Error"); }
           
        }
    }
}