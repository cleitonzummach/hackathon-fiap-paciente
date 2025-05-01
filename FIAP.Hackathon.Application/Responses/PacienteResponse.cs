using FIAP.Hackathon.Domain.Entities;

namespace FIAP.Hackathon.Application.Responses
{
    public class PacienteResponse
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public PacienteResponse(Paciente paciente)
        {
            Nome = paciente.Nome;
            Endereco = string.Format("{0} - {1}/{2} - {3}", paciente.Endereco, paciente.Cidade, paciente.Estado, paciente.CEP);
            Email = paciente.Email;
        }
    }
}
