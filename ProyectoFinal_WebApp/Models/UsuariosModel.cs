using ProyectoFinal_WebApp.Entities;

namespace ProyectoFinal_WebApp.Models
{
    public class UsuariosModel
    {
        public UsuarioObj? ConsultarUsuario(string cedula,IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            UsuarioObj usuario = new UsuarioObj();
            usuario.Cedula = cedula;
            
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(usuario);

                string metodo = "Mantenimiento/ConsultarUsuario";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode && respuesta.Content != null)
                {
                    return respuesta.Content.ReadFromJsonAsync<UsuarioObj>().Result;
                }
                else
                {
                    return null;
                }              
            }
        }
        public int EditarUsuario(UsuarioObj usuario, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {

                JsonContent body = JsonContent.Create(usuario);

                string metodo = "Mantenimiento/EditarUsuario";
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
