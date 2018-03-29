using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YahtzeeLight.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YahtzeeLight.Controllers
{
    public class StartController : Controller
    {
        public ViewResult Index()
        {

            DiceRandom.random = new Random();
            return View();
        }

        
    }
}
