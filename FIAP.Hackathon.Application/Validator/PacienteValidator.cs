using FIAP.Hackathon.Application.Requests;
using FluentValidation;
using System.Globalization;

namespace FIAP.Hackathon.Application.Validator
{
    public class PacienteValidator : AbstractValidator<PacienteRequest>
    {
        public PacienteValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode ter mais de 100 caracteres.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Must(CpfValidator.IsValid).WithMessage("O CPF informado é inválido.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(DataNascimentoFormatValid).WithMessage("A data de nascimento informada é inválida. Formato: DD/MM/YYYY")
                .Must(DataNascimentoValid).WithMessage("A data de nascimento informada deve ser menor que a data atual.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .Must(EmailValidator.IsValid).WithMessage("O e-mail informado é inválido.");

            RuleFor(p => p.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória");
        }

        public static bool DataNascimentoFormatValid(string dataNascimento) 
        {
            return DateTime.TryParseExact(dataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);
        }

        public static bool DataNascimentoValid(string dataNascimento)
        {
            DateTime.TryParseExact(dataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);
            return dt < DateTime.Now;
        }
    }
}
