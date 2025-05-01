using FIAP.Hackathon.Application.Requests;
using FIAP.Hackathon.Application.Services;
using FIAP.Hackathon.Domain.Entities;
using FIAP.Hackathon.Domain.Repositories;
using Moq;
using System.Globalization;

namespace FIAP.Hackathon.Tests.PacienteServicesTests
{
    public class PacienteServiceTestsBase
    {
        protected readonly Mock<IPacienteRepository> _mockPacienteRepository;
        protected readonly PacienteService _pacienteService;

        public PacienteServiceTestsBase()
        {
            _mockPacienteRepository = new Mock<IPacienteRepository>();
            _pacienteService = new PacienteService(_mockPacienteRepository.Object);
        }

        protected PacienteRequest GerarPacienteRequestValido()
        {
            return new PacienteRequest
            {
                Nome = "João da Silva",
                CPF = "123.456.789-00",
                DataNascimento = "10/05/1990",
                Endereco = "Rua das Flores, 123",
                Cidade = "Estância Velha",
                Estado = "RS",
                CEP = "93600-000",
                Email = "joao@email.com",
                Senha = "senha123"
            };
        }

        protected Paciente GerarPacienteValido()
        {
            var request = GerarPacienteRequestValido();
            return new Paciente(
                request.Nome,
                request.CPF,
                new DateTime(DateTime.ParseExact(request.DataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture).Ticks, DateTimeKind.Utc),
                request.Endereco,
                request.Cidade,
                request.Estado,
                request.CEP,
                request.Email,
                request.Senha
            );
        }
    }
}
