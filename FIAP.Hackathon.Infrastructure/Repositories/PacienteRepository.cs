using FIAP.Hackathon.Domain.Entities;
using FIAP.Hackathon.Domain.Repositories;
using FIAP.Hackathon.Infrastructure.Data.Context;

namespace FIAP.Hackathon.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HackathonDBContext _context;
        
        public PacienteRepository(HackathonDBContext context) 
        {
            _context = context;
        }

        public Paciente? RetornarPorId(Guid id)
        {
            return _context.Paciente.FirstOrDefault(x => x.PacienteId == id);
        }

        public Paciente? ValidarLogin(string email, string senha)
        {
            return _context.Paciente.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public bool Criar(Paciente paciente)
        {
            try
            {
                _context.Paciente.Add(paciente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Editar(Paciente paciente)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Excluir(Paciente paciente)
        {
            try
            {
                _context.Remove(paciente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
