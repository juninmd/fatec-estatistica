using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoBinomial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class DistribuicaoBinomialTest
    {

        [TestMethod]
        public void Input()
        {
            var elemento = new DistribuicaoBinomialEntity
            {
                N = 20,
                KInput = 18,
                TipoEntrada = 2
            };
            var build = new DistribuicaoBinomialApp().Fatorial(elemento.KInput, elemento.TipoEntrada, elemento.N);

            var elemento2 = new DistribuicaoBinomialEntity
            {
                N = 20,
                KInput = 15,
                TipoEntrada = 0
            };
            var build2 = new DistribuicaoBinomialApp().Fatorial(elemento2.KInput, elemento2.TipoEntrada, elemento2.N);
        }


    }
}
