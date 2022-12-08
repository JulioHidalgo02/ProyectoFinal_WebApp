namespace ProyectoFinal_WebApp.Entities
{
    public class UsuarioObj
    {
        public string Cedula { get; set; } = String.Empty;
        public string Correo { get; set; } = String.Empty;
        public string Nombre { get; set; } = String.Empty;
        public string PApellido { get; set; } = String.Empty;
        public string SApellido { get; set; } = String.Empty;
        public string Telefono { get; set; } = String.Empty;
        public string Direccion { get; set; } = String.Empty;
    }

    public class UsuarioObj2
    {
        public string Cedula { get; set; } = String.Empty;
        public string Correo { get; set; } = String.Empty;
        public string Nombre { get; set; } = String.Empty;
        public string PApellido { get; set; } = String.Empty;
        public string SApellido { get; set; } = String.Empty;
        public string Telefono { get; set; } = String.Empty;
        public string Direccion { get; set; } = String.Empty;

        public List<FacturaObj> listaCarrito { get; set; }
    }
}
