using FIAP.Hackathon.Domain.Entities;
using Moq;

namespace FIAP.Hackathon.Tests.PacienteServicesTests
{
    public class EditarPacienteServiceTests : PacienteServiceTestsBase
    {
        private readonly Guid _pacienteId = Guid.NewGuid();

        [Fact]
        public void EditarPaciente_PacienteExiste_RetornaTrue_QuandoEditaComSucesso()
        {
            // Arrange
            var request = GerarPacienteRequestValido();
            var pacienteExistente = new Paciente("Nome Antigo", "CPF Antigo", DateTime.UtcNow, "Endereco Antigo", "Cidade Antiga", "Estado Antigo", "CEP Antigo", "email@antigo.com", "senhaAntiga");
            pacienteExistente.PacienteId = _pacienteId;
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns(pacienteExistente);
            _mockPacienteRepository.Setup(repo => repo.Editar(It.IsAny<Paciente>())).Returns(true);

            // Act
            var resultado = _pacienteService.EditarPaciente(_pacienteId, request);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EditarPaciente_PacienteExiste_RetornaFalse_QuandoErroAoEditar()
        {
            // Arrange
            var request = GerarPacienteRequestValido();
            var pacienteExistente = new Paciente("Nome Antigo", "CPF Antigo", DateTime.UtcNow, "Endereco Antigo", "Cidade Antiga", "Estado Antigo", "CEP Antigo", "email@antigo.com", "senhaAntiga");
            pacienteExistente.PacienteId = _pacienteId;
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns(pacienteExistente);
            _mockPacienteRepository.Setup(repo => repo.Editar(It.IsAny<Paciente>())).Returns(false);

            // Act
            var resultado = _pacienteService.EditarPaciente(_pacienteId, request);

            // Assert
            Assert.False(resultado);
            _mockPacienteRepository.Verify(repo => repo.RetornarPorId(_pacienteId), Times.Once);
            _mockPacienteRepository.Verify(repo => repo.Editar(It.IsAny<Paciente>()), Times.Once);
        }

        [Fact]
        public void EditarPaciente_PacienteNaoExiste_RetornaFalse()
        {
            // Arrange
            var request = GerarPacienteRequestValido();
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns((Paciente?)null);

            // Act
            var resultado = _pacienteService.EditarPaciente(_pacienteId, request);

            // Assert
            Assert.False(resultado);
        }
    }
}
