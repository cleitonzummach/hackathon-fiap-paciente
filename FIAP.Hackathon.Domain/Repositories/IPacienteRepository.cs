using FIAP.Hackathon.Domain.Entities;

namespace FIAP.Hackathon.Domain.Repositories
{
    public interface IPacienteRepository
    {
        Paciente? RetornarPorId(Guid id);
        IEnumerable<Paciente>? RetornarTodos();
        Paciente? ValidarLogin(string email, string senha);
        bool Criar(Paciente paciente);
        bool Editar(Paciente paciente);
    }
}
