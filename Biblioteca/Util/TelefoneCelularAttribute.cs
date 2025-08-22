using System.ComponentModel.DataAnnotations;


namespace Util
{
    /// <summary>
    /// Validação customizada para telefone celular
    /// </summary>
    public class TelefoneCelularAttribute : ValidationAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public TelefoneCelularAttribute() { }

        /// <summary>
        /// Validação server
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return true;
            var celular = Methods.RemoveNaoNumericos(value.ToString());
            // Telefone celular deve ter 11 dígitos, não começar com zero e conter apenas números
            if (celular.Length != 11 || celular.StartsWith("0") || !Methods.SoContemNumeros(celular))
                return false;
            return true;
        }

        public override string FormatErrorMessage(string name) => $"O campo {name} contém um número de celular inválido.";
    }
}