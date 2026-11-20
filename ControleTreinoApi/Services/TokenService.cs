using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ControleTreinoApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearer.Services;

public interface ITokenService
{
    string Generate(Usuario usuario);
}

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string Generate(Usuario usuario)
    {
        var chave = configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("Jwt:Key não está configurada (user-secrets).");

        var bytes = Encoding.UTF8.GetBytes(chave);
        if (bytes.Length < 32)
            throw new InvalidOperationException("Jwt:Key deve ter pelo menos 32 caracteres.");

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(bytes),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new (JwtRegisteredClaimNames.Email, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}