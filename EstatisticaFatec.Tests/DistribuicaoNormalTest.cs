using System.Collections.Generic;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Const;
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
            var entidade = new DistribuicaoNormalEntity
            {
                DesvioPadrao = 2000,
                MediaPonderada = 10000,
                TipoEntrada = 1,
                Valor = new[] { new decimal(11000) }
            };


            var teste = new DistribuicaoNormalApp().Build(entidade);
        }
    }
}
