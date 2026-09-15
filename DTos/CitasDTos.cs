namespace StyleBookBarberBD.DTos
{
    public class CitasDTos
    {
        public int ClienteId { get; set; }
        public int BarberoId { get; set; }
        public int ServicioId { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; } = "Pendiente";
    }
}
