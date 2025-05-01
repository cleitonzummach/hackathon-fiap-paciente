namespace FIAP.Hackathon.Application.Validator
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais (CPF inválido)
            if (cpf.All(c => c == cpf[0]))
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma1 = 0;
            for (int i = 0; i < 9; i++)
            {
                soma1 += int.Parse(cpf[i].ToString()) * multiplicadores1[i];
            }
            int resto1 = soma1 % 11;
            int digitoVerificador1 = (resto1 < 2) ? 0 : 11 - resto1;

            // Verifica o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
            {
                return false;
            }

            // Calcula o segundo dígito verificador
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma2 = 0;
            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(cpf[i].ToString()) * multiplicadores2[i];
            }
            int resto2 = soma2 % 11;
            int digitoVerificador2 = (resto2 < 2) ? 0 : 11 - resto2;

            // Verifica o segundo dígito verificador
            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
            {
                return false;
            }

            return true;
        }
    }
}
