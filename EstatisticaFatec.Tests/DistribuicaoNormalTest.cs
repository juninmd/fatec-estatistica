using System.Collections.Generic;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class DistribuicaoNormalTest
    {
        [TestMethod]
        public void Input()
        {
            var numeros = new DistribuicaoNormalEntity 
            {
                
            };

            var teste = new DistribuicaoNormalApp().Build(numeros);
        }
    }
}
