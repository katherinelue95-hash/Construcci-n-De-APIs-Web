// Models/Cita.cs
namespace StyleBookBarberBD.Models
{
    public class Citas
    {
        public int CitaId { get; set; }
        public int ClienteId { get; set; }
        public int BarberoId { get; set; }
        public int ServicioId { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public Usuarios? Cliente { get; set; }
        public Barberos? Barbero { get; set; }
        public Servicios? Servicio { get; set; }
    }
}

