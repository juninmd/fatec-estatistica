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
        [TestMethod]
        public void Core()
        {
            var listaCore = new EstratificadaUniformeApp().Core((decimal)61 / 7, 7);

            var lista = new EstratificadaUniformeApp().Core((decimal)100 / 3, 3);
        }
    }
}
