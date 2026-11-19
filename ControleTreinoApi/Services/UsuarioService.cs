using ControleTreinoApi.Dtos;
using ControleTreinoApi.Exceptions;
using ControleTreinoApi.Models;
using ControleTreinoApi.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ControleTreinoApi.Services;

public class UsuarioService(IUsuarioRepository repository, IPasswordHasher<Usuario> hasher) : IUsuarioService
{
    public async Task<UsuarioResponse> CadastrarAsync(CadastroRequest request)
    {
        var email = request.Email.Trim().ToLowerInvariant();   

        if (await repository.EmailExisteAsync(email))
            throw new EmailJaCadastradoException();            

        var usuario = new Usuario { Nome = request.Nome.Trim(), Email = email };
        usuario.SenhaHash = hasher.HashPassword(usuario, request.Senha);   

        await repository.AdicionarAsync(usuario);
        return new UsuarioResponse(usuario.Id, usuario.Nome, usuario.Email);
    }
}