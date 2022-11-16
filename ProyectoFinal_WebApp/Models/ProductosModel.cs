using ProyectoFinal_WebApp.Entities;

namespace ProyectoFinal_WebApp.Models
{
    public class ProductosModel
    {
        public List<ProductoObj2>? MostrarProductos(IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                string metodo = "Mantenimiento/MostrarProductos";
                HttpResponseMessage respuesta = client.GetAsync(ruta + metodo).Result;

                if (respuesta.IsSuccessStatusCode && respuesta.Content != null)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<ProductoObj2>>().Result;
                }
                else
                {
                    return null;
                }

                
        }
    }

        public ProductoObj2? MostrarProducto(ProductoObj2 producto, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(producto);

                string metodo = "Mantenimiento/MostrarUnProducto";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProductoObj2>().Result;
                }
                else
                {
                    return null;
                }


            }
        }

        public int EditarProducto(ProductoObj2 producto, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(producto);

                string metodo = "Mantenimiento/EditarProducto";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }


            }
        }

        public int AgregarProducto(ProductoObj producto, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(producto);

                string metodo = "Mantenimiento/RegistarProducto";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }


            }
        }

        public int EliminarProducto(ProductoObj2 producto, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(producto);

                string metodo = "Mantenimiento/EliminarProducto";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }


            }
        }

    }
}
