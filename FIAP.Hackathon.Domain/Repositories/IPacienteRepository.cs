using FIAP.Hackathon.Domain.Entities;

namespace FIAP.Hackathon.Domain.Repositories
{
    public interface IPacienteRepository
    {
        Paciente? RetornarPorId(Guid id);
        Paciente? ValidarLogin(string email, string senha);
        bool Criar(Paciente paciente);
        bool Editar(Paciente paciente);
        bool Excluir(Paciente paciente);
    }
}
