using ControleTreinoApi.Data;
using ControleTreinoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleTreinoApi.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> EmailExisteAsync(string email)
    {
        return await _context.Usuarios.AnyAsync(u => u.Email == email);
    }

    public async Task<Usuario> AdicionarAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }
}