using System.Collections.Generic;
using EstatisticaFatec.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class MedidasDispersaoTest
    {
        [TestMethod]
        public void CV()
        {
            var manteiga  = MathCoreApp.Porcentagem(25, 500);
            var arroz  = MathCoreApp.Porcentagem(100, 5000);

        }
        [TestMethod]
        public void Input()
        {
            var antonio = new List<decimal>()
            {
                3,7,10,4
            };
            var antonioResult = new MedidasDispersaoApp().Build(antonio);

            /* `X */
            Assert.IsTrue(antonioResult.InputValue[0] == 3, "O Valor deveria ser 3");
            Assert.IsTrue(antonioResult.InputValue[1] == 7, "O Valor deveria ser 7");
            Assert.IsTrue(antonioResult.InputValue[2] == 10, "O Valor deveria ser 10");
            Assert.IsTrue(antonioResult.InputValue[3] == 4, "O Valor deveria ser 4");

            Assert.IsTrue(antonioResult.InputValueQuadrado[0] == 9);
            Assert.IsTrue(antonioResult.InputValueQuadrado[1] == 1);
            Assert.IsTrue(antonioResult.InputValueQuadrado[2] == 16);
            Assert.IsTrue(antonioResult.InputValueQuadrado[3] == 4);

            Assert.IsTrue(antonioResult.Media == new decimal(6));


            var pedro = new List<decimal>()
            {
               4,5,10,6
            };

            var pedroResult = new MedidasDispersaoApp().Build(pedro);


            Assert.IsTrue(pedroResult.InputValueQuadrado[0] == 4);
            Assert.IsTrue(pedroResult.InputValueQuadrado[1] == 5);
            Assert.IsTrue(pedroResult.InputValueQuadrado[2] == 10);
            Assert.IsTrue(pedroResult.InputValueQuadrado[3] == 6);

            Assert.IsTrue(pedroResult.InputValueQuadrado[0] == new decimal(5.06), "O Valor deveria ser = 5.06");
            Assert.IsTrue(pedroResult.InputValueQuadrado[1] == new decimal(1.56), "O Valor deveria ser 1.56");
            Assert.IsTrue(pedroResult.InputValueQuadrado[2] == new decimal(14.06), "O Valor deveria ser 14.06)");
            Assert.IsTrue(pedroResult.InputValueQuadrado[3] == new decimal(0.06), "O Valor deveria ser 0.06");
            Assert.IsTrue(pedroResult.Media == new decimal(6.25));


            var gasolina = new List<decimal>()
            {
                new decimal(2.61),
                 new decimal(2.64),
                 new decimal(2.56),
                 new decimal(2.61),
                 new decimal(2.60),
                 new decimal(2.58)
            };

            var gasolinaResult = new MedidasDispersaoApp().Build(gasolina);



        }
    }
}
