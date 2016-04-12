using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class DistribuicaoNormalTest
    {
        [TestMethod]
        public void Input()
        {
            var numeros = new List<int>
            {
                20,37,40,32,28,26,25,32,39,40,50,47,46,31,24,21,35,39,38,43
            };

            var teste = new DistribuicaoNormalApp().Build(1, 3, 4);
        }
    }
}
