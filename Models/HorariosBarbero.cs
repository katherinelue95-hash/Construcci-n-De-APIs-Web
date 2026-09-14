// Models/HorarioBarbero.cs
namespace StyleBookBarberBD.Models
{
    public class HorariosBarbero
    {
        public int HorarioId { get; set; }
        public int BarberoId { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public Barberos? Barbero { get; set; }
    }
}
