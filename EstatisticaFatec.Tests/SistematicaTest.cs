using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class SistematicaTest
    {
        [TestMethod]
        public void Input()
        {
            var lista = new SistematicaApp().Build(6, 2, 10);
        }
    }
}
