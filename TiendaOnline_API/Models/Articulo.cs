namespace TiendaOnline_API.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set;}
        public string Marca { get; set;}
        public string Categoria { get; set;}
        public decimal Precio { get; set;}
    }
}
