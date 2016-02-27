using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class EstratificadaUniformeTest
    {
        [TestMethod]
        public void Input()
        {
            var lista = new EstratificadaUniformeApp().Build(3, 10);
        }
    }
}
