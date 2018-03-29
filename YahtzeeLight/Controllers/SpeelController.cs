using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YahtzeeLight.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YahtzeeLight.Controllers
{
    public class SpeelController : Controller
    {
        [HttpPost]
        public ViewResult Gegevens(string naam)
        {
            if (string.IsNullOrEmpty(naam)) {
                ViewBag.Error = "Je moet een naam invoeren!";
                return View();
            }

            Speler speler = new Speler()
            {
                Naam = naam,
                SpelerID = Database.getID()
            };

            Database.VoegSpelerToe(speler);

            return View();
        }

        [HttpGet]
        public ViewResult Gegevens()
        {
            return View();
        }

        public ViewResult Uitslag()
        {
            Game.genereerWorpen();

            List<Speler> spelers = Database.getSpelersOrderedByScore();

            ViewBag.spelers = spelers;

            return View();
        }

        public ActionResult NieuweSpelers()
        {
            Database.ClearSpelers();
            return RedirectToAction("Gegevens");
        }

    }
}
