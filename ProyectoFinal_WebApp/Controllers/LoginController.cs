﻿using Microsoft.AspNetCore.Mvc;
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
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginObj usuario )
        {
            var respuesta = model.ValidarUsuario(usuario, _configuration);

            if(respuesta != null)
            {

                HttpContext.Session.SetString("RolUsuario", respuesta.IdRol.ToString());
                HttpContext.Session.SetString("Cedula", respuesta.Cedula);
                HttpContext.Session.SetString("NombreUsuario", respuesta.Nombre + " " + respuesta.PApellido);
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
        public IActionResult CerrarSesion()
        {

            return RedirectToAction("Login", "Login");
        }
    }
}