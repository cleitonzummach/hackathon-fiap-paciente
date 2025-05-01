namespace FIAP.Hackathon.Domain.Entities
{
    public class Paciente
    {
        public Guid PacienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataExclusao { get; set; }

        public Paciente() { }

        public Paciente(string nome, string cpf, DateTime dataNascimento, string? endereco, string? cidade, string? estado, string? cep, string email, string senha)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Email = email;
            Senha = senha;
        }

        public void Excluir() 
        {
            DataExclusao = DateTime.UtcNow;
        }
    }
}
