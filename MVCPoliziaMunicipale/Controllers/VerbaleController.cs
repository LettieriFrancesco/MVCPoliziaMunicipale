using MVCPoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        public List<SelectListItem> DescrizioneViolazioni
        {
            get
            {
                List<Violazioni> listaViolazioni = new List<Violazioni>();
                listaViolazioni = DB.ListaViolazioni();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Violazioni v in listaViolazioni)
                {
                    SelectListItem select = new SelectListItem { Text = v.DescrizioneViolazione, Value = v.IdViolazione.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        public List<SelectListItem>DescrizioneTrasgressore
        {
            get
            {
                List<Trasgressore> listaTrasgressori = new List<Trasgressore>();
                listaTrasgressori = DB.ListaTrasgressori();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach(Trasgressore t in listaTrasgressori)
                {
                    SelectListItem select = new SelectListItem { Text = $"{t.Nome} {t.Cognome}" , Value = t.Id.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        // GET: Verbale
        public ActionResult Index()
        {
            List<Verbale>Verbali = DB.ListaVerbali();
            return View(Verbali);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listaTrasgressori = DescrizioneTrasgressore;
            ViewBag.listaViolazioni = DescrizioneViolazioni; 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Verbale verbali)
        {
            if (ModelState.IsValid)
            {
                DB.CreaVerbale(verbali);
                return RedirectToAction("Index");
            }
            else { return View("Error"); }
        }
        [HttpGet]
        public ActionResult TotVerbaliTrasgressori()
        {
            List<VerbaliPerTrasgressori> verbali = DB.VerbaliPerOgniTrasgressore();
            return View(verbali);
        }
        [HttpGet]
        public ActionResult TotPuntiDecurtatiTrasgressori()
        {
            List<PuntiDecPerTrasgressore> puntiDecurtati = DB.PuntiPerOgniTrasgressore();
            return View(puntiDecurtati);
        }
        [HttpGet]
        public ActionResult Over10Punti()
        {
            List<ViolazioneOver10Punti> puntiOv10 = DB.PuntiOver10PerOgniTrasgressore();
            return View(puntiOv10);
        }
        [HttpGet]
        public ActionResult Over400Euro()
        {
            List<VerbaliOver400> verbOver400 = DB.VerbaliOver400PerTrasgressore();
            return View(verbOver400);
        }
    }
}