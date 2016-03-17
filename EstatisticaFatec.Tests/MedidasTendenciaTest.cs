using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class MedidasTendenciaTest
    {
        [TestMethod]
        public void Input()
        {
            var inputs = new List<decimal>
            {
                3,
                4,
                new decimal(3.5),
                5,
                new decimal(3.5),
                4,
                5,
                new decimal(5.5),
                4,
                5
            };
            var resultado = new MedidasTendenciaApp().Build(inputs);

            Assert.IsTrue(resultado.Media == new decimal(4.25));
            Assert.IsTrue(resultado.Mediana == 4);
            Assert.IsTrue(resultado.Moda[0] == 4 && resultado.Moda[1] == 5);
        }
    }
}