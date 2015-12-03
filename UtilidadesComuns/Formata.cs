using System.Linq;

namespace UtilidadesComuns
{
    /// <summary>
    /// Classe utilizada para formatar números, documentos, telefones, etc.
    /// </summary>
    public static class Formata
    {
        /// <summary>
        /// Formata um número de acordo com o padrão da NFe (três blocos separados por ponto). 
        /// Ex.: 12 -> 000.000.012
        /// </summary>
        /// <param name="nroNota">Número a ser formatado</param>
        /// <returns>Número da NFe formatado com o padrão do Danfe</returns>
        public static string NumeroNfe_Danfe(int nroNota)
        {
            var str = nroNota.ToString().PadLeft(9, '0');

            return $"{str.Substring(0, 3)}.{str.Substring(3, 3)}.{str.Substring(6, 3)}";
        }

        /// <summary>
        /// Formatar uma chave de NFe de acordo com o padrão da NFe (11 blocos de 4 dígitos separados por espaço)
        /// Ex.: 1111 2222 3333 4444 5555 6666 7777 8888 9999 0000 1111
        /// </summary>
        /// <param name="chaveNfe">Chave a ser formatada</param>
        /// <returns>Chave da NFe formatada com o padrão do Danfe</returns>
        public static string ChaveNfe_Danfe(int chaveNfe)
        {
            return ChaveNfe_Danfe(chaveNfe.ToString());
        }

        /// <summary>
        /// Formatar uma chave de NFe de acordo com o padrão da NFe (11 blocos de 4 dígitos separados por espaço)
        /// Ex.: 1111 2222 3333 4444 5555 6666 7777 8888 9999 0000 1111
        /// </summary>
        /// <param name="chave">Chave a ser formatada</param>
        /// <returns>Chave da NFe formatada com o padrão do Danfe</returns>
        public static string ChaveNfe_Danfe(string chave)
        {
            if (string.IsNullOrEmpty(chave) || chave.Length < 44)
                return chave;

            var arr = Enumerable.Range(0, chave.Length / 4).Select(i => chave.Substring(i * 4, 4));
            // Isso divide a string em vários blocos com 4 posições cada um - pra evitar de repetir o substring() 11 vezes

            return string.Join(" ", arr);
        }

        /// <summary>
        /// Formatar CEP com o padrão XXXXX-XXX
        /// Ex.: 93510320 -> 93510-320
        /// </summary>
        /// <param name="cep">CEP a ser formatado</param>
        /// <returns>CEP formatado</returns>
        public static string Cep(long cep)
        {
            var str = cep.ToString();

            if (str.Length < 8)
                return str;

            return $"{str.Substring(0, 5)}-{str.Substring(5)}";
        }

        /// <summary>
        /// Formatar telefone com o padrão (XX) XXXX-XXXX (8 dígitos) ou (XX) XXXX-XXXXX (9 dígitos)
        /// Ex.: 5198987878 -> (51) 9898-7878
        /// </summary>
        /// <param name="telefone">Número de telefone a ser formatado</param>
        /// <returns>Telefone formatado</returns>
        public static string Telefone(int telefone)
        {
            return Telefone(telefone.ToString());
        }

        /// <summary>
        /// Formatar telefone com o padrão (XX) XXXX-XXXX (8 dígitos) ou (XX) XXXX-XXXXX (9 dígitos)
        /// Ex.: 5198987878 -> (51) 9898-7878
        /// </summary>
        /// <param name="telefone">Número de telefone a ser formatado</param>
        /// <returns>Telefone formatado</returns>
        public static string Telefone(long telefone)
        {
            return Telefone(telefone.ToString());
        }

        /// <summary>
        /// Formatar telefone com o padrão (XX) XXXX-XXXX (8 dígitos) ou (XX) XXXX-XXXXX (9 dígitos)
        /// Ex.: 5198987878 -> (51) 9898-7878
        /// </summary>
        /// <param name="telefone">Número de telefone a ser formatado</param>
        /// <returns>Telefone formatado</returns>
        public static string Telefone(string telefone)
        {
            string ret;

            if (string.IsNullOrWhiteSpace(telefone))
                return telefone;

            switch (telefone.Length)
            {
                case 10:
                case 11:
                    ret = $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 4)}-{(telefone.Length == 10 ? telefone.Substring(6, 4) : telefone.Substring(6, 5))}";
                    break;
                case 8:
                case 9:
                    ret = $"{telefone.Substring(0, 4)}-{(telefone.Length == 8 ? telefone.Substring(4, 4) : telefone.Substring(4, 5))}";
                    break;
                default:
                    return telefone;
            }

            return ret;
        }

        /// <summary>
        /// Valida se a entrada é um CPF ou CNPJ e formata com o padrão
        /// </summary>
        /// <param name="valor">Valor a ser formatado</param>
        /// <returns>Valor formatado</returns>
        public static string CpfCnpj(long valor)
        {
            return CpfCnpj(valor.ToString());
        }

        /// <summary>
        /// Valida se a entrada é um CPF ou CNPJ e formata com o padrão
        /// </summary>
        /// <param name="value">Valor a ser formatado</param>
        /// <returns>Valor formatado</returns>
        public static string CpfCnpj(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var str = InternalUtils.SomenteNumeros(value);

            if (str.Length <= 11)
                return Cpf(str);

            if (str.Length > 11)
                return Cnpj(str);

            return value;
        }

        /// <summary>
        /// Formatar CPF com o padrão XXX.XXX.XXX-XX
        /// </summary>
        /// <param name="arg">CPF a ser formatado</param>
        /// <returns>CPF formatado</returns>
        public static string Cpf(long arg)
        {
            return Cpf(arg.ToString());
        }

        /// <summary>
        /// Formatar CPF com o padrão XXX.XXX.XXX-XX
        /// </summary>
        /// <param name="cpf">CPF a ser formatado</param>
        /// <returns>CPF formatado</returns>
        public static string Cpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return cpf;

            cpf = cpf.PadLeft(11, '0');
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        /// <summary>
        /// Formatar CNPJ com o padrão XXX.XXX.XXX/XXXX-XX
        /// </summary>
        /// <param name="arg">CNPJ a ser formatado</param>
        /// <returns>CNPJ formatado</returns>
        public static string Cnpj(long arg)
        {
            return Cnpj(arg.ToString());
        }

        /// <summary>
        /// Formatar CNPJ com o padrão XXX.XXX.XXX/XXXX-XX
        /// </summary>
        /// <param name="cnpj">CNPJ a ser formatado</param>
        /// <returns>CNPJ formatado</returns>
        public static string Cnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return cnpj;

            cnpj = cnpj.PadLeft(14, '0');
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }
    }
}

