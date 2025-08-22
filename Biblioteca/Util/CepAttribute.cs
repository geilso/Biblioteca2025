using System.ComponentModel.DataAnnotations;

namespace Util
{
    // Validação customizada para CEP
    public class CepAttribute : ValidationAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public CepAttribute() { }

        /// <summary>
        /// Validação server
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return true;

            var cep = Methods.RemoveNaoNumericos(value.ToString());

            // CEP deve ter 8 dígitos e não começar com zero
            if (cep.Length != 8 || cep.StartsWith("0") || !Methods.SoContemNumeros(cep))
                return false;

            return true;
        }

        public override string FormatErrorMessage(string name) => $"O campo {name} contém um CEP inválido.";
    }
}
