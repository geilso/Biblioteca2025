using System.ComponentModel.DataAnnotations;

namespace Util
{
    // Validação customizada para telefone fixo
    public class TelefoneFixoAttribute : ValidationAttribute
    {
        // Construtor
        public TelefoneFixoAttribute() { }

        // Validação server
        // <param name="value"></param>
        // <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return true;
            var fixo = Methods.RemoveNaoNumericos(value.ToString());
            // Telefone fixo deve ter 10 dígitos, não começar com zero e conter apenas números
            if (fixo.Length != 10 || fixo.StartsWith("0") || !Methods.SoContemNumeros(fixo))
                return false;
            return true;
        }

        public override string FormatErrorMessage(string name) => $"O campo {name} contém um telefone fixo inválido.";
    }
}

