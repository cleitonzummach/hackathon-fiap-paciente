using FIAP.Hackathon.Domain.Entities;

namespace FIAP.Hackathon.Tests.TokenServicesTests
{
    public class RetornarTokenServiceTests : TokenServiceTestsBase
    {
        private const string EmailValido = "teste@email.com";
        private const string SenhaValida = "senha123";

        [Fact]
        public void RetornarToken_CredenciaisValidas_RetornaTokenJWT()
        {
            // Arrange
            Paciente pacienteValido = new Paciente("Nome Teste", "CPF Teste", DateTime.UtcNow, "Endereco Teste", "Cidade Teste", "Estado Teste", "CEP Teste", "email@teste.com", "senha");
            pacienteValido.PacienteId = Guid.NewGuid();
            _mockPacienteRepository.Setup(repo => repo.ValidarLogin(EmailValido, SenhaValida)).Returns(pacienteValido);

            // Act
            var tokenString = _tokenService.RetornarToken(EmailValido, SenhaValida);

            // Assert
            Assert.NotNull(tokenString);
            Assert.NotEmpty(tokenString);
        }

        [Fact]
        public void RetornarToken_CredenciaisInvalidas_RetornaNull()
        {
            // Arrange
            _mockPacienteRepository.Setup(repo => repo.ValidarLogin(EmailValido, SenhaValida)).Returns((Paciente?)null);

            // Act
            var tokenString = _tokenService.RetornarToken(EmailValido, SenhaValida);

            // Assert
            Assert.NotNull(tokenString);
            Assert.Empty(tokenString);
        }
    }
}
