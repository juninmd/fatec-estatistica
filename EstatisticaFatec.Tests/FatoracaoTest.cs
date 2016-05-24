using System;
using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class FatoracaoTest
    {
        [TestMethod]
        public void Input()
        {
            var fatorA = MathCoreApp.Fatorial(6);


            var fatorB = MathCoreApp.Fatorial(1);
            var fatorC = MathCoreApp.Fatorial(6 - 1);

            var result = fatorA / (fatorB * fatorC);

            var resultb = (result * Math.Pow(0.9, 1) * Math.Pow(0.1, 5)) * 100;
        }
    }
}

