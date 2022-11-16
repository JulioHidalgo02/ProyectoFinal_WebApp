
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using ProyectoFinal_WebApp.Entities;
using ProyectoFinal_WebApp.Models;
using System.Configuration;
using System.IO;

namespace ProyectoFinal_WebApp.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IConfiguration _configuration;
        ProductosModel productosM = new ProductosModel();

        public ProductosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult MostrarProductos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminProductos()
        {
            var resultado = productosM.MostrarProductos(_configuration);
            return View(resultado);
        }

        [HttpGet]
        public IActionResult AgregarProducto()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(ProductoObj producto)
        {
            string path = Path.GetFileName(producto.URL);
            

            return RedirectToAction("AgregarProducto", "Productos");
           
        }

        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            ProductoObj2 producto = new ProductoObj2();
            producto.IdInventario = id;
            var resultado = productosM.MostrarProducto(producto, _configuration);


            return View(resultado);

        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoObj2 producto)
        {


            var resultado = productosM.EditarProducto(producto,_configuration);
            if(resultado == 1)
            {
                return RedirectToAction("AdminProductos", "Productos");
            }
            else
            {
                return RedirectToAction("EditarProducto", "Productos");
            }
            

        }

        [HttpPost]
        public IActionResult EliminarProducto(int id)
        {

            ProductoObj2 producto = new ProductoObj2();
            producto.IdInventario = id;
            var resultado = productosM.EliminarProducto(producto, _configuration);
            if (resultado == 1)
            {
                return RedirectToAction("AdminProductos", "Productos");
            }
            else
            {
                return RedirectToAction("AdminProductos", "Productos");
            }


        }


        [HttpGet]
        public IActionResult MostrarProductoIndividual()
        {
            return View();
        }

    }
}
