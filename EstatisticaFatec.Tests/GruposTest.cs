using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class GruposTest
    {
        [TestMethod]
        public void Input()
        {
            var inputs = new List<decimal>()
            {
              1,1,1,1,1,1,1,1,1,2,
            };
            var app = new AgrupamentoApp().Build(inputs);
        }
    }
}

