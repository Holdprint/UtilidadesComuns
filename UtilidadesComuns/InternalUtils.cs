using System.Text.RegularExpressions;

namespace UtilidadesComuns
{
    internal class InternalUtils
    {
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
