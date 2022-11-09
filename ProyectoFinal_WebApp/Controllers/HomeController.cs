using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProyectoFinal_WebApp.Controllers
{
    public class HomeController : Controller
    {
      
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Acercade()
        {
            return View();
        }


    }
}