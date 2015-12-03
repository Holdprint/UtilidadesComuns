using System.Collections.Generic;
using System.Linq;

using static System.Convert;

namespace UtilidadesComuns
{
    public class Valida
    {
        public static bool Cpf(long cpf)
        {
            //Algoritmo retirado de http://www.geradorcpf.com/algoritmo_do_cpf.htm

            string strCpf = cpf.ToString().PadLeft(11, '0');

            if (strCpf.All(x => x == strCpf[0]))
                return false;

            var listCpf = strCpf.Select(num => ToInt32(num.ToString())).ToList();
            //listCpf.RemoveRange(10, 2);

            if (listCpf[9] != Mod11Cpf(listCpf, 10))
                return false;

            if (listCpf[10] != Mod11Cpf(listCpf, 11))
                return false;

            return true;
        }

        internal static int Mod11Cpf(List<int> elementos, int @base)
        {
            int soma = 0;
            for (int i = 0; i < (@base - 1); i++)
                soma += (@base - i) * elementos[i];

            int dv1, resto = soma % 11;

            if (resto < 2)
                dv1 = 0;
            else
                dv1 = 11 - resto;

            return dv1;
        }

        public static bool Cnpj(long cnpj)
        {
            //Algoritmo retirado de http://www.geradorcpf.com/algoritmo_do_cnpj.htm

            string strCnpj = cnpj.ToString().PadLeft(14, '0');

            if (strCnpj.All(x => x == strCnpj[0]))
                return false;

            var listCnpj = strCnpj.Select(num => ToInt32(num.ToString())).ToList();
            listCnpj.RemoveRange(12, 2);

            int dv1 = Mod11Cnpj(listCnpj);
            if (ToInt32(strCnpj[12].ToString()) != dv1)
                return false;

            listCnpj.Add(dv1);

            int dv2 = Mod11Cnpj(listCnpj);
            if (ToInt32(strCnpj[13].ToString()) != dv2)
                return false;

            return true;
        }

        internal static int Mod11Cnpj(List<int> elementos)
        {
            int soma = 0;
            int multiplicador = 2;
            for (int i = elementos.Count - 1; i >= 0; i--)
            {
                soma += elementos[i] * multiplicador;

                if (multiplicador == 9)
                    multiplicador = 2;
                else
                    multiplicador++;
            }

            int resto = soma % 11;

            if (resto < 2)
                return 0;

            return 11 - resto;
        }
    }
}
