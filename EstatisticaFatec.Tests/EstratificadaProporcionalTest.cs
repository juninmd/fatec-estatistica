using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class EstratificadaProporcionalTest
    {
        [TestMethod]
        public void Input()
        {
            var estratos = new List<int>
            {
               1,2,3
            };

            var lista = new EstratificadaProporcionalApp().Build(3, estratos, 10);
        }
    }
}
