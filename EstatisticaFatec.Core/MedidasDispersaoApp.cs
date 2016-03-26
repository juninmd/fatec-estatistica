using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.MedidasDispersao;

namespace EstatisticaFatec.Core
{
    /// <summary>
    /// <para>Classe responsável por calcular</para>
    /// <para>Variancia | DP | CV</para>
    /// </summary>
    public class MedidasDispersaoApp
    {

        public MedidasDispersaoEntity Calcular(decimal xifi, decimal fiSum, decimal media)
        {
            var Variancia = MathCoreApp.Variancia(xifi, fiSum);

            var DP = MathCoreApp.RaizQuadrada(Variancia);

            var CV = MathCoreApp.Porcentagem(DP, media);

            return new MedidasDispersaoEntity
            {
                CV = CV,
                Variancia = Variancia,
                DP = DP,
            };
        }
        public MedidasDispersaoContainerEntity Build(List<decimal> inputData)
        {
            var media = MathCoreApp.MediaComum(inputData);

            var InputValueQuadrado = MathCoreApp.SomaTodosAoQuadrado(inputData, media);

            var SomaInputValueQuadrado = InputValueQuadrado.Sum();

            var medidasDispersao = Calcular(SomaInputValueQuadrado, inputData.Count, media);

            return new MedidasDispersaoContainerEntity()
            {
                Media = media,
                Rol = MathCoreApp.Rol(inputData),
                InputValue = inputData,
                InputValueQuadrado = InputValueQuadrado,
                SomaInputValueQuadrado = SomaInputValueQuadrado,
                MedidasDispersaoEntity = medidasDispersao
            };
        }
    }
}
