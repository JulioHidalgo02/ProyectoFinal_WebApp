using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal_WebApp.Controllers
{
    public class ProductosController : Controller
    {
        [HttpGet]
        public IActionResult MostrarProductos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MostrarProductoIndividual()
        {
            return View();
        }
    }
}
