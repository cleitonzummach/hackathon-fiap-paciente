using FIAP.Hackathon.Application.Services;
using FIAP.Hackathon.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;

namespace FIAP.Hackathon.Tests.TokenServicesTests
{
    public class TokenServiceTestsBase
    {
        protected readonly Mock<IConfiguration> _mockConfiguration;
        protected readonly Mock<IPacienteRepository> _mockPacienteRepository;
        protected readonly TokenService _tokenService;
        protected const string JwtKey = "0a9bae4face847a78541f9757e3f874f";

        public TokenServiceTestsBase()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockPacienteRepository = new Mock<IPacienteRepository>();

            _mockConfiguration.Setup(config => config["JwtKey"]).Returns(JwtKey);
            _mockConfiguration.Setup(config => config.GetSection("JwtKey").Value).Returns(JwtKey);

            _tokenService = new TokenService(_mockConfiguration.Object, _mockPacienteRepository.Object);
        }
    }
}
