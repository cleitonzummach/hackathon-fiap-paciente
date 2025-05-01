using FIAP.Hackathon.Domain.Entities;
using Moq;

namespace FIAP.Hackathon.Tests.PacienteServicesTests
{
    public class ExcluirPacienteServiceTests : PacienteServiceTestsBase
    {
        private readonly Guid _pacienteId = Guid.NewGuid();

        [Fact]
        public void ExcluirPaciente_PacienteExiste_RetornaTrue_QuandoExcluiComSucesso()
        {
            // Arrange
            Paciente pacienteExistente = new Paciente("Nome", "CPF", DateTime.UtcNow, "Endereco", "Cidade", "Estado", "CEP", "email@email.com", "senha");
            pacienteExistente.PacienteId = _pacienteId;
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns(pacienteExistente);
            _mockPacienteRepository.Setup(repo => repo.Excluir(It.IsAny<Paciente>())).Returns(true);

            // Act
            var resultado = _pacienteService.ExcluirPaciente(_pacienteId);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void ExcluirPaciente_PacienteExiste_RetornaFalse_QuandoErroAoExcluir()
        {
            // Arrange
            Paciente pacienteExistente = new Paciente("Nome", "CPF", DateTime.UtcNow, "Endereco", "Cidade", "Estado", "CEP", "email@email.com", "senha");
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns(pacienteExistente);
            _mockPacienteRepository.Setup(repo => repo.Excluir(It.IsAny<Paciente>())).Returns(false);

            // Act
            var resultado = _pacienteService.ExcluirPaciente(_pacienteId);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void ExcluirPaciente_PacienteNaoExiste_RetornaFalse()
        {
            // Arrange
            _mockPacienteRepository.Setup(repo => repo.RetornarPorId(_pacienteId)).Returns((Paciente?)null);

            // Act
            var resultado = _pacienteService.ExcluirPaciente(_pacienteId);

            // Assert
            Assert.False(resultado);
        }
    }
}
