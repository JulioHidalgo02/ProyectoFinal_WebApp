using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_WebApp.Entities;
using ProyectoFinal_WebApp.Models;

namespace ProyectoFinal_WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private LoginModel model = new LoginModel();

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginObj usuario )
        {
            var respuesta = model.ValidarUsuario(usuario, _configuration);

            if(respuesta != null)
            {
                
              return RedirectToAction("Index", "Home");
                

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HacerRegistro()
        {
            return View();
        }
    }
}
