using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.MedidasDispersao;

namespace EstatisticaFatec.Core
{
    public class MedidasDispersaoApp
    {
        /// <summary>
        /// Retorna o valor E(xi-`x) / E(xi).length - 1
        /// </summary>
        /// <param name="inutData"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        private decimal DivideV2PorQuantidade(decimal inutData, int quantidade)
        {
            return inutData / (quantidade - 1);
        }

        public MedidasDispersaoEntity Build(List<decimal> inputData)
        {
            var media = MathCoreApp.MediaComum(inputData);

            var InputValueQuadrado = MathCoreApp.SomaTodosAoQuadrado(inputData, media);

            var SomaInputValueQuadrado = InputValueQuadrado.Sum();

            var Variancia = DivideV2PorQuantidade(SomaInputValueQuadrado, inputData.Count);

            var DP = MathCoreApp.RaizQuadrada(Variancia);

            var CV = MathCoreApp.Porcentagem(DP, media);

            return new MedidasDispersaoEntity
            {
                CV = CV,
                Media = media,
                Rol = MathCoreApp.Rol(inputData),
                InputValue = inputData,
                Variancia = Variancia,
                InputValueQuadrado = InputValueQuadrado,
                DP = DP,
                SomaInputValueQuadrado = SomaInputValueQuadrado
            };
        }
    }
}
