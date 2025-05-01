using FIAP.Hackathon.Application.Requests;
using FIAP.Hackathon.Application.Responses;

namespace FIAP.Hackathon.Application.Interfaces
{
    public interface IPacienteService
    {
        bool CriarPaciente(PacienteRequest request);
        bool EditarPaciente(Guid pacienteId, PacienteRequest request);
        bool ExcluirPaciente(Guid pacienteId);
        PacienteResponse? RetornarPorId(Guid pacienteId);
    }
}
