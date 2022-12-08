using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_WebApp.Entities;
using ProyectoFinal_WebApp.Models;
using System.Text.Json;

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
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginObj usuario )
        {
            var respuesta = model.ValidarUsuario(usuario, _configuration);

            if(respuesta != null)
            {
                var carrito = new List<FacturaObj>();
                var contenido = JsonSerializer.Serialize(carrito);

                HttpContext.Session.SetString("DatosCarrito", contenido);
                HttpContext.Session.SetString("RolUsuario", respuesta.IdRol.ToString());
                HttpContext.Session.SetString("Cedula", respuesta.Cedula);
                HttpContext.Session.SetString("NombreUsuario", respuesta.Nombre + " " + respuesta.PApellido);
                HttpContext.Session.SetString("Correo", respuesta.Correo);
                HttpContext.Session.SetString("Telefono", respuesta.Telefono);
                HttpContext.Session.SetString("Direccion", respuesta.Direccion);
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
        public IActionResult Registrarse(LoginObj2 usuario)
        {
            var respuesta = model.RegistrarUsuario(usuario, _configuration);
            if(respuesta == 1)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult OlvidoContrasena()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OlvidoContrasena(LoginObj2 usuario)
        {
            var respuesta = model.OlvidoContrasenia(usuario, _configuration);
            if (respuesta == 1)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(Contacto contacto)
        {
            var respuesta = model.RegistrarContacto(contacto, _configuration);
            if (respuesta == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult CerrarSesion()
        {

            return RedirectToAction("Login", "Login");
        }
    }
}
