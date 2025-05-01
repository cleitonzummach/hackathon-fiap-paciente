using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using FIAP.Hackathon.Application.Interfaces;
using FIAP.Hackathon.Domain.Repositories;

namespace FIAP.Hackathon.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IPacienteRepository _pacienteRepository;

        public TokenService(IConfiguration configuration, IPacienteRepository pacienteRepository)
        {
            _configuration = configuration;
            _pacienteRepository = pacienteRepository;
        }

        public string RetornarToken(string email, string senha)
        {
            var paciente = _pacienteRepository.ValidarLogin(email, senha);

            if (paciente != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                // Busca a chave secreta do JWT do arquivo de configuração.
                var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtKey").Value);

                var tokenPropriedades = new SecurityTokenDescriptor()
                {
                    // Dados do usuário dentro do token.
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, paciente.PacienteId.ToString()),
                    new Claim(ClaimTypes.Email, email)
                    }),

                    // Tempo de expiração do token.
                    Expires = DateTime.UtcNow.AddHours(1),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografia), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenPropriedades);

                return tokenHandler.WriteToken(token);
            }

            return string.Empty;
        }
    }
}
