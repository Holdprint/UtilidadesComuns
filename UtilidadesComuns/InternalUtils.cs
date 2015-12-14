using System.Text.RegularExpressions;

namespace Holdprint.Utils
{
    internal class InternalUtils
    {
        /// <summary>
        /// Remover todos os caracteres não numéricos de uma string
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        internal static string SomenteNumeros(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            var rgx = new Regex(@"[^\d]");
            string res = rgx.Replace(texto, "");

            return res;
        }
    }
}
