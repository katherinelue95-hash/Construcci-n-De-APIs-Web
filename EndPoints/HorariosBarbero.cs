using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleBookBarberBD.Data;
using StyleBookBarberBD.DTos;
using StyleBookBarberBD.DTOs;
using StyleBookBarberBD.Models;

namespace StyleBookBarberBD.EndPoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosBarberoController : ControllerBase
    {
        private readonly StyleBookBarberBDContext _context;
        private readonly IMapper _mapper;

        public HorariosBarberoController(StyleBookBarberBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/HorariosBarbero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorariosBarberoDTos>>> GetHorarios()
        {
            var horarios = await _context.HorariosBarbero.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<HorariosBarberoDTos>>(horarios));
        }

        // GET: api/HorariosBarbero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorariosBarberoDTos>> GetHorario(int id)
        {
            var horario = await _context.HorariosBarbero.FindAsync(id);
            if (horario == null) return NotFound();

            return Ok(_mapper.Map<HorariosBarberoDTos>(horario));
        }

        // POST: api/HorariosBarbero
        [HttpPost]
        public async Task<ActionResult<HorariosBarberoDTos>> PostHorario(HorariosBarberoDTos dto)
        {
            var horario = _mapper.Map<HorariosBarbero>(dto);
            _context.HorariosBarbero.Add(horario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHorario), new { id = horario.HorarioId }, _mapper.Map<HorariosBarberoDTos>(horario));
        }

        // PUT: api/HorariosBarbero/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorario(int id, HorariosBarberoDTos dto)
        {
            if (id != dto.HorarioId) return BadRequest();

            var horario = await _context.HorariosBarbero.FindAsync(id);
            if (horario == null) return NotFound();

            _mapper.Map(dto, horario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/HorariosBarbero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            var horario = await _context.HorariosBarbero.FindAsync(id);
            if (horario == null) return NotFound();

            _context.HorariosBarbero.Remove(horario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

