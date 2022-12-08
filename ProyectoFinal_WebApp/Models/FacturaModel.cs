using ProyectoFinal_WebApp.Entities;

namespace ProyectoFinal_WebApp.Models
{
    public class FacturaModel
    {
        public int AgregarFactura(FacturaObj factura, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(factura);

                string metodo = "Mantenimiento/RegistrarFactura";
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

        public int AgregarDetalleFactura(FacturaObj factura, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(factura);

                string metodo = "Mantenimiento/RegistrarDetalleFactura";
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
