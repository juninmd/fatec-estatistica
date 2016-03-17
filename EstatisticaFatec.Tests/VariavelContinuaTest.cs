using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class VariavelContinuaTest
    {
        [TestMethod]
        public void Input()
        {
            var numeros = new List<decimal>
            {
                20,37,40,32,28,26,25,32,39,40,50,47,46,31,24,21,35,39,38,43
            };

            var lista = new VariavelContinuaApp().Build(numeros);
        }
    }
}
