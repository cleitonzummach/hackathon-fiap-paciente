using FIAP.Hackathon.Application.Interfaces;
using FIAP.Hackathon.Application.Requests;
using FIAP.Hackathon.Application.Responses;
using FIAP.Hackathon.Domain.Entities;
using FIAP.Hackathon.Domain.Repositories;
using System.Globalization;
using System.Linq;

namespace FIAP.Hackathon.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository) 
        {
            _pacienteRepository = pacienteRepository;
        }

        public bool CriarPaciente(PacienteRequest request)
        {
            try
            {
                Paciente paciente = new Paciente(
                    request.Nome,
                    request.CPF,
                    new DateTime(DateTime.ParseExact(request.DataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture).Ticks, DateTimeKind.Utc),
                    request.Endereco,
                    request.Cidade,
                    request.Estado,
                    request.CEP,
                    request.Email,
                    request.Senha);

                return _pacienteRepository.Criar(paciente);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditarPaciente(Guid pacienteId, PacienteRequest request)
        {
            try
            {
                Paciente? paciente = _pacienteRepository.RetornarPorId(pacienteId);

                if (paciente != null)
                {
                    paciente.Nome = request.Nome;
                    paciente.CPF = request.CPF;
                    paciente.DataNascimento = new DateTime(DateTime.ParseExact(request.DataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture).Ticks, DateTimeKind.Utc);
                    paciente.Endereco = request.Endereco;
                    paciente.Cidade = request.Cidade;
                    paciente.Estado = request.Estado;
                    paciente.CEP = request.CEP;
                    paciente.Email = request.Email;
                    paciente.Senha = request.Senha;

                    return _pacienteRepository.Editar(paciente);
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExcluirPaciente(Guid pacienteId)
        {
            try
            {
                Paciente? paciente = _pacienteRepository.RetornarPorId(pacienteId);

                if (paciente != null)
                {
                    paciente.Excluir();
                    return _pacienteRepository.Editar(paciente);
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PacienteResponse? RetornarPorId(Guid pacienteId)
        {
            var paciente = _pacienteRepository.RetornarPorId(pacienteId);

            if (paciente != null)
                return new PacienteResponse(paciente);

            return null;
        }

        public IEnumerable<PacienteResponse>? RetornarTodos()
        {
            var pacientes = _pacienteRepository.RetornarTodos();

            if (pacientes != null)
                return pacientes.Select(paciente => new PacienteResponse(paciente));

            return null;
        }
    }
}
