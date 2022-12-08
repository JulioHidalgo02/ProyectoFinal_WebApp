using System.ComponentModel;

namespace ProyectoFinal_WebApp.Entities
{
    public class VentasObj
    {
        [DisplayName("Id Factura")]
        public int IdFactura { get; set; } = 0;
        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        [DisplayName("Correo Electrónico")]
        public string Correo { get; set; } = string.Empty;
        [DisplayName("Teléfono")]
        public string Telefono { get; set; } = string.Empty;
        [DisplayName("Fecha de la Compra")]
        public DateTime Fecha { get; set; } = default(DateTime);
        [DisplayName("Total Compra")]
        public decimal Total { get; set; } = 0;
    }
}
