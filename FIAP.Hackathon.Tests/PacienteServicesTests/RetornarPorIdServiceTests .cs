using FIAP.Hackathon.Application.Responses;
using FIAP.Hackathon.Domain.Entities;

namespace FIAP.Hackathon.Tests.PacienteServicesTests
{
    public class RetornarPorIdServiceTests : PacienteServiceTestsBase
    {
        private readonly Guid _pacienteId = Guid.NewGuid();

        [Fact]
        public void RetornarPorId_PacienteExiste_RetornaPacienteResponse()
        {
            // Arrange
            Paciente pacienteRetornado = new Paciente("Nome", "CPF", DateTime.UtcNow, "Endereco", "Cidade", "Estado", "CEP", "email@email.com", "senha");
            pacienteRetornado.PacienteId = _pacienteId;
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns(pacienteRetornado);

            // Act
            var resultado = _pacienteService.RetornarPorId(_pacienteId);

            // Assert
            Assert.NotNull(resultado);
            Assert.IsType<PacienteResponse>(resultado);
            Assert.Equal(pacienteRetornado.Nome, resultado.Nome);
            Assert.Equal(pacienteRetornado.Email, resultado.Email);
        }

        [Fact]
        public void RetornarPorId_PacienteNaoExiste_RetornaNull()
        {
            // Arrange
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns((Paciente?)null);

            // Act
            var resultado = _pacienteService.RetornarPorId(_pacienteId);

            // Assert
            Assert.Null(resultado);
        }
    }
}
