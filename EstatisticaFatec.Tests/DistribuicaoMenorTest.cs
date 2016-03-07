using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class DistribuicaoMenorTest
    {
        [TestMethod]
        public void Input()
        {
          var x =  new DistribuicaoMenorApp().Build(5,10,2);
        }
    }
}
