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

        public int RegistrarUsuario(LoginObj2 obj, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(obj);

                string metodo = "Login/RegistarUsuarioCliente";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }

                return -1;
            }
        }

        public int OlvidoContrasenia(LoginObj2 obj, IConfiguration stringConnection)
        {
            UsuarioObj usuario = new UsuarioObj();
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            usuario.Correo = obj.Correo;
            var resultado = ConsultarUsuarioPorCorreo(usuario, stringConnection);
            if(resultado == 1)
            {
                using (var client = new HttpClient())
                {
                    JsonContent body = JsonContent.Create(obj);

                    string metodo = "Mantenimiento/OlvidoContrasenia";
                    HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        return 1;
                    }

                    return -1;
                }
            }
            else
            {
                return -1;
            }
            
        }

        public int ConsultarUsuarioPorCorreo(UsuarioObj obj, IConfiguration stringConnection)
        {
            string ruta = stringConnection.GetSection("ConnectionStrings:UrlApi").Value;
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(obj);

                string metodo = "Mantenimiento/ConsultarUsuarioPorCorreo";
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode && respuesta.Content != null)
                {
                    return 1;
                }

                return -1;
            }
        }
    }
}
