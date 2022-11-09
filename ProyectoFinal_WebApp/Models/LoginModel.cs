using ProyectoFinal_WebApp.Entities;

namespace ProyectoFinal_WebApp.Models
{
    public class LoginModel
    {
        public LoginObj ValidarUsuario(LoginObj obj, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(obj);

                string metodo = "Login/ValidarUsuario";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<LoginObj>().Result;
                }

                return null;
            }
        }
    }
}
