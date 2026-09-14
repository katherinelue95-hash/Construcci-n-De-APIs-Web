// Models/Servicio.cs
namespace StyleBookBarberBD.Models
{
    public class Servicios
    {
        public int ServicioId { get; set; }
        public int CategoriaId { get; set; }
        public string NombreServicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMin { get; set; }
        public Categorias? Categoria { get; set; }
    }
}