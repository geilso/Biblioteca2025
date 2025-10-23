using System.ComponentModel.DataAnnotations;

namespace Util
{
    // Validação customizada para CPF
    public class CPFAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return true;
            var cpf = Methods.RemoveNaoNumericos(value.ToString());
            return Methods.ValidarCpf(cpf);
        }

        public override string FormatErrorMessage(string name) => $"O campo {name} contém um CPF inválido.";
    }
}

