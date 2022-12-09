using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_WebApp.Entities;
using ProyectoFinal_WebApp.Models;
using System.Reflection;
using System.Text.Json;

namespace ProyectoFinal_WebApp.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IConfiguration _configuration;
        private FacturaModel model = new FacturaModel();

        public CarritoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult AgregarAlCarrito()
        {
            var carritoActual = HttpContext.Session.GetString("DatosCarrito");
            var contenido = JsonSerializer.Deserialize<List<FacturaObj>>(carritoActual);

            return View(contenido);
        }
        [HttpPost]
        public IActionResult AgregarAlCarrito(ProductoObj2 producto)
        {
            FacturaObj obj = new FacturaObj();
            obj.Producto = producto.NombreProducto;
            obj.Precio = producto.Precio;
            obj.CANTCOMPRADA = producto.CantComprar;
            obj.IDPRODUCTO = producto.IdInventario;
            obj.TOTAL_LINEA = (producto.Precio * producto.CantComprar);
            var carritoActual = HttpContext.Session.GetString("DatosCarrito");
            var contenido = JsonSerializer.Deserialize<List<FacturaObj>>(carritoActual);
            obj.IDUSUARIO = HttpContext.Session.GetString("Cedula");
            if(contenido.Count < 1)
            {
                contenido.Add(new FacturaObj { CANTCOMPRADA = obj.CANTCOMPRADA, IDPRODUCTO = obj.IDPRODUCTO, IDUSUARIO = obj.IDUSUARIO, Producto = obj.Producto, Precio = obj.Precio, TOTAL_LINEA = obj.TOTAL_LINEA });
            }else if (contenido.Count >= 1)
            {
                if(contenido.Last().Producto == obj.Producto)
                {
                    foreach (var item in contenido/*.Where(x => x.IDPRODUCTO == obj.IDPRODUCTO)*/)
                    {
                        if (item.IDPRODUCTO == obj.IDPRODUCTO)
                        {
                            item.CANTCOMPRADA = item.CANTCOMPRADA + obj.CANTCOMPRADA;
                            item.TOTAL_LINEA = (item.CANTCOMPRADA * item.Precio);
                        }
                    }
                }
                else
                {
                    contenido.Add(new FacturaObj { CANTCOMPRADA = obj.CANTCOMPRADA, IDPRODUCTO = obj.IDPRODUCTO, IDUSUARIO = obj.IDUSUARIO, Producto = obj.Producto, Precio = obj.Precio, TOTAL_LINEA = obj.TOTAL_LINEA });
                }
                
            }
            
            
            var contenidoNuevo = JsonSerializer.Serialize(contenido);
            HttpContext.Session.SetString("DatosCarrito", contenidoNuevo);
            carritoActual = HttpContext.Session.GetString("DatosCarrito");
            contenido = JsonSerializer.Deserialize<List<FacturaObj>>(carritoActual);
            return View(contenido);

        }
            [HttpPost]
            public IActionResult VaciarCarrito(ProductoObj2 producto)
            {


                HttpContext.Session.Remove("DatosCarrito");
                var carrito = new List<FacturaObj>();
                var contenido = JsonSerializer.Serialize(carrito);

                HttpContext.Session.SetString("DatosCarrito", contenido);

                return RedirectToAction("Index", "Home");
            }

            [HttpGet]
            public IActionResult CheckOut()
            {
                UsuarioObj2 usuario = new UsuarioObj2();
                var Nombre = HttpContext.Session.GetString("NombreUsuario");
                var Correo = HttpContext.Session.GetString("Correo");
                var Telefono = HttpContext.Session.GetString("Telefono");
                var Direccion = HttpContext.Session.GetString("Direccion");

                var carritoActual = HttpContext.Session.GetString("DatosCarrito");
                var contenido = JsonSerializer.Deserialize<List<FacturaObj>>(carritoActual);
                usuario.Nombre = Nombre;
                usuario.Correo = Correo;
                usuario.Telefono = Telefono;
                usuario.Direccion = Direccion;
                usuario.listaCarrito = contenido;
                return View(usuario);

            }

            [HttpPost]
            public IActionResult CrearFactura()
            {
                FacturaObj factura = new FacturaObj();
                var Cedula = HttpContext.Session.GetString("Cedula");
                factura.IDUSUARIO = Cedula;
                model.AgregarFactura(factura, _configuration);
                var carritoActual = HttpContext.Session.GetString("DatosCarrito");
                var contenido = JsonSerializer.Deserialize<List<FacturaObj>>(carritoActual);
                foreach (var item in contenido)
                {
                    model.AgregarDetalleFactura(item, _configuration);
                }
                HttpContext.Session.Remove("DatosCarrito");
                var carrito = new List<FacturaObj>();
                var NuevoCarrito = JsonSerializer.Serialize(carrito);
                HttpContext.Session.SetString("DatosCarrito", NuevoCarrito);
                return RedirectToAction("Agradecimiento", "Carrito");

            }

            [HttpGet]
            public IActionResult Agradecimiento()
            {

                return View();

            }


        }
    }
