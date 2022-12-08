using ProyectoFinal_WebApp.Entities;

namespace ProyectoFinal_WebApp.Models
{
    public class VentasModel
    {
        public List<VentasObj>? MostrarVentas(IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                string metodo = "Mantenimiento/MostrarVentas";
                HttpResponseMessage respuesta = client.GetAsync(ruta + metodo).Result;

                if (respuesta.IsSuccessStatusCode && respuesta.Content != null)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<VentasObj>>().Result;
                }
                else
                {
                    return null;
                }


            }
        }
    }
}
