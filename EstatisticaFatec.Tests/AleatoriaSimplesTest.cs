using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class AleatoriaSimplesTest
    {
        [TestMethod]
        public void Input()
        {
            var lista = new AleatoriaSimplesApp().Build(6, 2);
        }
    }
}
