using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_WebApp.Models;

namespace ProyectoFinal_WebApp.Controllers
{
    public class VentasController : Controller
    {
        private readonly IConfiguration _configuration;
        private VentasModel model = new VentasModel();

        public VentasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult MostrarVentas()
        {
            var resultado = model.MostrarVentas(_configuration);
            return View(resultado);
        }
    }
}
