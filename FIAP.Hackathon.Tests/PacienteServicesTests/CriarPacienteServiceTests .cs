using FIAP.Hackathon.Domain.Entities;
using Moq;

namespace FIAP.Hackathon.Tests.PacienteServicesTests
{
    public class CriarPacienteServiceTests : PacienteServiceTestsBase
    {
        [Fact]
        public void CriarPaciente_RetornaTrue_QuandoCriaComSucesso()
        {
            // Arrange
            var request = GerarPacienteRequestValido();
            var pacienteEsperado = GerarPacienteValido();
            _mockPacienteRepository.Setup(repo => repo.Criar(It.IsAny<Paciente>())).Returns(true);

            // Act
            var resultado = _pacienteService.CriarPaciente(request);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void CriarPaciente_RetornaFalse_QuandoErroAoCriar()
        {
            // Arrange
            var request = GerarPacienteRequestValido();
            _mockPacienteRepository.Setup(repo => repo.Criar(It.IsAny<Paciente>())).Returns(false);

            // Act
            var resultado = _pacienteService.CriarPaciente(request);

            // Assert
            Assert.False(resultado);
        }
    }
}
