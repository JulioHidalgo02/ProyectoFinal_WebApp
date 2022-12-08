using Microsoft.AspNetCore.Mvc;
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

    }
}
