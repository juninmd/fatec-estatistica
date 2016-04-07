using System;
using System.Collections.Generic;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class MedidasTendenciaTest
    {
        [TestMethod]
        public void Input()
        {
            var inputs = new BaseInputsEntity
            {
                InputValue = new List<decimal>
                {
                    3,
                    4,
                    new decimal(3.5),
                    5,
                    new decimal(3.5),
                    4,
                    5,
                    new decimal(5.5),
                    4,
                    5
                }
            };

            var resultado = new MedidasTendenciaApp().Build(inputs);

            Assert.IsTrue(resultado.MedidasTendenciaEntity.Media == new decimal(4.25));
            Assert.IsTrue(resultado.MedidasTendenciaEntity.Mediana == 4);
            Assert.IsTrue(resultado.MedidasTendenciaEntity.Moda[0] == 4 && resultado.MedidasTendenciaEntity.Moda[1] == 5);
        }

        [TestMethod]
        public void MedianaQuantitativa()
        {
            var I = 36;
            var EFI = 20;
            var Fant = 8;
            var FIND = 9;
            var H = 8;

            var calculo = I + Math.Round((decimal)((EFI / 2) - Fant) / FIND * H, 2);
        }
    }
}