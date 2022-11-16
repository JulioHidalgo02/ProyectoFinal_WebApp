using System.ComponentModel;

namespace ProyectoFinal_WebApp.Entities
{
    public class ProductoObj
    {
        public string NOMPRODUCTO { get; set; } = String.Empty;
        public int PRECIO { get; set; } = 0;
        public int CANTDISPO { get; set; } = 0;
        public string DESCRIP { get; set; } = String.Empty;
        public string URL { get; set; } = String.Empty;
    }

    public class ProductoObj2
    {
        [DisplayName("Id Inventario")]
        public int IdInventario { get; set; } = 0;

        [DisplayName("Nombre del Producto")]
        public string NombreProducto { get; set; } = String.Empty;
        
        public int Precio { get; set; } = 0;

        [DisplayName("Cantidad Disponible")]
        public int CantDisponible { get; set; } = 0;
        [DisplayName("Descripción")]
        public string DescripcionProducto { get; set; } = String.Empty;

        [DisplayName("Imagen")]
        public string URLimagen { get; set; } = String.Empty;
        
    }
}
