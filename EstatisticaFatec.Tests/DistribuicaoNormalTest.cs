using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class DistribuicaoNormalTest
    {
        private DistribuicaoNormalEntity EntidadeA(decimal?[] lista)
        {
            return new DistribuicaoNormalEntity
            {
                DesvioPadrao = 2000,
                MediaPonderada = 10000,
                TipoEntrada = 0,
                Valor = lista
            };
        }
        [TestMethod]
        public void Input()
        {
            Menor();
            Entre();
            Maior();
        }

        private void Teste(DistribuicaoNormalEntity distribuicao, double valor)
        {
            var teste = new DistribuicaoNormalApp().Build(distribuicao);
            Assert.AreEqual(teste.Probabilidade, valor, "O valor da probabilidade não está correto");
        }

        [TestMethod]
        public void Menor()
        {
            Teste(EntidadeA(new[] { new decimal?(11000) }), 30.85);
            Teste(EntidadeA(new[] { new decimal?(8000) }), 84.13);
          
        }

        [TestMethod]
        public void Entre()
        {
            var entidade = new DistribuicaoNormalEntity
            {
                DesvioPadrao = 2000,
                MediaPonderada = 10000,
                TipoEntrada = 1,
                Valor = new[] { new decimal?(9000), new decimal?(12000) }
            };
            var teste = new DistribuicaoNormalApp().Build(entidade);
            Assert.AreEqual(teste.Probabilidade, new decimal(53.28), "O valor da probabilidade não está correto");

            var entidade2 = new DistribuicaoNormalEntity
            {
                DesvioPadrao = 2000,
                MediaPonderada = 10000,
                TipoEntrada = 1,
                Valor = new[] { new decimal?(8000), new decimal?(9000) }
            };
            var teste2 = new DistribuicaoNormalApp().Build(entidade2);
            Assert.AreEqual(teste2.Probabilidade, new decimal(14.98), "O valor da probabilidade não está correto");
        }

        [TestMethod]
        public void Maior()
        {
            var entidade = new DistribuicaoNormalEntity
            {
                DesvioPadrao = 2000,
                MediaPonderada = 10000,
                TipoEntrada = 2,
                Valor = new[] { new decimal?(10000), new decimal?(12000) }
            };

            var teste = new DistribuicaoNormalApp().Build(entidade);

        }
    }
}
