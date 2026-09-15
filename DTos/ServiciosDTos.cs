namespace StyleBookBarberBD.DTos
{
    public class ServiciosDTos
    {
        public int ServicioId { get; set; }
        public string NombreServicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMin { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}
