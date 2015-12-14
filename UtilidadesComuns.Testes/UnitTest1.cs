using System;
using UtilidadesComuns;
using NUnit;
using NUnit.Framework;

namespace UtilidadesComuns.Testes
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        [TestCase(40958666164)]
        [TestCase(98445392000)]
        [TestCase(37174723136)]
        [TestCase(58551407848)]
        [TestCase(11144477735)]
        public void ValidaCpf(long cpf)
        {
            Assert.IsTrue(Valida.Cpf(cpf));
        }

        [Test]
        [TestCase(29196030517)]
        [TestCase(40958666166)]
        [TestCase(98445392005)]
        [TestCase(37174723134)]
        [TestCase(58551407843)]
        public void ValidaCpf_fail(long cpf)
        {
            Assert.IsFalse(Valida.Cpf(cpf));
        }

        [Test]
        [TestCase(11444777000161)]
        [TestCase(16538964000128)]
        [TestCase(77863742000175)]
        [TestCase(26683018000129)]
        [TestCase(45225851000170)]
        public void ValidaCnpj(long cnpj)
        {
            Assert.IsTrue(Valida.Cnpj(cnpj));
        }

        [Test]
        [TestCase(11444777000163)]
        [TestCase(16538964000125)]
        [TestCase(77863742000176)]
        [TestCase(26683018000124)]
        [TestCase(45225851000173)]
        public void ValidaCnpj_Fail(long cnpj)
        {
            Assert.IsFalse(Valida.Cnpj(cnpj));
        }

        [Test]
        [TestCase(3319085069)]
        public void FormataCpf(long cpf)
        {
            var formatado = Formata.Cpf(cpf);
        }

        [Test]
        [TestCase(6538964000128)]
        public void FormataCnpj(long cnpj)
        {
            var formatado = Formata.Cnpj(cnpj);
        }
    }
}
