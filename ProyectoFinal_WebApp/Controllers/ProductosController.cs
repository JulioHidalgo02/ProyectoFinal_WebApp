
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using ProyectoFinal_WebApp.Entities;
using ProyectoFinal_WebApp.Helper;
using ProyectoFinal_WebApp.Models;
using ProyectoFinal_WebApp.Providers;
using System.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


namespace ProyectoFinal_WebApp.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IConfiguration _configuration;
        private HelperUploadFiles helperUpload;
        ProductosModel productosM = new ProductosModel();

        public ProductosController(HelperUploadFiles helperUpload,IConfiguration configuration)
        {
            _configuration = configuration;
            this.helperUpload = helperUpload;
        }

        [HttpGet]
        public IActionResult MostrarProductos()
        {
            try
            {
                var resultado = productosM.MostrarProductos(_configuration);
                return View(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult AdminProductos()
        {
            try
            {
                var resultado = productosM.MostrarProductos(_configuration);
                return View(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult AgregarProducto()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto(IFormFile imagen, ProductoObj producto)
        {
            try
            {
                string nombreImagen = imagen.FileName;
                string path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Images);
                path = "/images/" + nombreImagen;
                producto.URL = path;

                var resultado = productosM.AgregarProducto(producto, _configuration);

                if (resultado == 1)
                {
                    return RedirectToAction("AdminProductos", "Productos");
                }
                else
                {
                    return RedirectToAction("AgregarProducto", "Productos");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            try
            {
                ProductoObj2 producto = new ProductoObj2();
                producto.IdInventario = id;
                var resultado = productosM.MostrarProducto(producto, _configuration);


                return View(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoObj2 producto)
        {
            try
            {
                var resultado = productosM.EditarProducto(producto, _configuration);
                if (resultado == 1)
                {
                    return RedirectToAction("AdminProductos", "Productos");
                }
                else
                {
                    return RedirectToAction("EditarProducto", "Productos");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult EliminarProducto(int id)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet]
        public IActionResult MostrarProductoIndividual(int id)
        {
            try
            {
                ProductoObj2 producto = new ProductoObj2();
                producto.IdInventario = id;
                var resultado = productosM.MostrarProducto(producto, _configuration);
                return View(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
