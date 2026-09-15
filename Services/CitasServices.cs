using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StyleBookBarberBD.Data;
using StyleBookBarberBD.DTos;
using StyleBookBarberBD.DTOs;
using StyleBookBarberBD.Models;

namespace StyleBookBarberBD.Services
{
    public class CitasServices
    {
        private readonly StyleBookBarberBDContext _context;
        private readonly IMapper _mapper;

        public CitasServices(StyleBookBarberBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CitasDTos>> GetCitasAsync()
        {
            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Barbero)
                .Include(c => c.Servicio)
                .ToListAsync();

            return _mapper.Map<List<CitasDTos>>(citas);
        }

        public async Task<CitasDTos?> GetCitaByIdAsync(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Barbero)
                .Include(c => c.Servicio)
                .FirstOrDefaultAsync(c => c.CitaId == id);

            return cita != null ? _mapper.Map<CitasDTos>(cita) : null;
        }

        public async Task<CitasDTos> CrearCitaAsync(CitasDTos dto)
        {
            var cita = _mapper.Map<Citas>(dto);
            cita.Estado = "Pendiente";

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return _mapper.Map<CitasDTos>(cita);
        }
    }
}

