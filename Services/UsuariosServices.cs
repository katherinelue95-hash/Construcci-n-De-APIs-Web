using Microsoft.EntityFrameworkCore;
using StyleBookBarberBD.Data;
using StyleBookBarberBD.DTOs;
using StyleBookBarberBD.Models;
using AutoMapper;

namespace StyleBookBarberBD.Services
{
    public class UsuariosServices
    {
        private readonly StyleBookBarberBDContext _context;
        private readonly IMapper _mapper;

        public UsuariosServices(StyleBookBarberBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RegistroDTO>> GetUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.Include(u => u.Rol).ToListAsync();
            return _mapper.Map<List<RegistroDTO>>(usuarios);
        }

        public async Task<RegistroDTO?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.Include(u => u.Rol)
                                                 .FirstOrDefaultAsync(u => u.UsuarioId == id);
            return usuario != null ? _mapper.Map<RegistroDTO>(usuario) : null;
        }

        public async Task<RegistroDTO> CrearUsuarioAsync(RegistroDTO dto)
        {
            var usuario = _mapper.Map<Usuarios>(dto);
            usuario.RolId = 1; // Por defecto, cliente
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegistroDTO>(usuario);
        }
    }
}
