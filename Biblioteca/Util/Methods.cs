using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public class Methods
    {
        public static string RemoveSpecialsCaracts(string? poluatedString)
        {
            if (string.IsNullOrEmpty(poluatedString)) return string.Empty;
            return Regex.Replace(poluatedString, @"[^0-9a-zA-Z_]", string.Empty);
        }

        public static string RemoverAcentos(string? texto)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;
            return new string(texto
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }


        /// <summary>
        /// Retorna CPF com padrão de caracteres - máscara
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static string PatternCpf(string? cpf)
        {
            cpf = RemoveNaoNumericos(cpf ?? string.Empty);
            if (cpf.Length != 11) return cpf;
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        /// <summary>
        /// Remove caracteres não numéricos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNaoNumericos(string? text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return Regex.Replace(text, @"[^0-9]", string.Empty);
        }

        public static bool ValidarCpf(string? cpf)
        {
            cpf = RemoveNaoNumericos(cpf ?? string.Empty);
            if (cpf.Length != 11) return false;
            if (cpf.All(c => c == cpf[0])) return false; // Evita CPFs com todos os dígitos iguais

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool ValidarCnpj(string? cnpj)
        {
            cnpj = RemoveNaoNumericos(cnpj ?? string.Empty);
            if (cnpj.Length != 14) return false;
            if (cnpj.All(c => c == cnpj[0])) return false; // Evita CNPJs com todos os dígitos iguais

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool SoContemNumeros(string? texto)
        {
            texto = RemoveNaoNumericos(texto ?? string.Empty);
            return !string.IsNullOrEmpty(texto) && Regex.IsMatch(texto, "^[0-9]+$");
        }

        public static bool SoContemLetras(string? texto)
        {
            if (string.IsNullOrEmpty(texto)) return false;
            texto = texto.Replace(".", "").Replace("-", "");
            return Regex.IsMatch(texto, @"^([a-zA-Z ])*$");
        }
    }
}
