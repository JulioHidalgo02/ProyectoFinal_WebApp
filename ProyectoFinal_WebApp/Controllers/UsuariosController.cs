using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_WebApp.Entities;
using ProyectoFinal_WebApp.Models;

namespace ProyectoFinal_WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IConfiguration _configuration;
        private UsuariosModel model = new UsuariosModel();

        public UsuariosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult EditarUsuario()
        {
            try
            {
                var cedula = HttpContext.Session.GetString("Cedula");
                var resultado = model.ConsultarUsuario(cedula, _configuration);
                HttpContext.Session.Remove("NombreUsuario");
                HttpContext.Session.Remove("Correo");
                HttpContext.Session.Remove("Telefono");
                HttpContext.Session.Remove("Direccion");
                HttpContext.Session.SetString("NombreUsuario", resultado.Nombre + " " + resultado.PApellido);
                HttpContext.Session.SetString("Correo", resultado.Correo);
                HttpContext.Session.SetString("Telefono", resultado.Telefono);
                HttpContext.Session.SetString("Direccion", resultado.Direccion);

                return View(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult EditarUsuario(UsuarioObj usuario)
        {
            try
            {
                var resultado = model.EditarUsuario(usuario, _configuration);
                if (resultado == 1)
                {
                    return RedirectToAction("EditarUsuario", "Usuarios");
                }
                else
                {
                    return RedirectToAction("EditarUsuario", "Usuarios");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
