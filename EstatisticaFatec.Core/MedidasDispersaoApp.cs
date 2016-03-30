using System;
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



        /// <summary>
        /// Comum
        /// </summary>
        /// <param name="listaXifi"></param>
        /// <param name="media"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static decimal Variancia(List<decimal> listaXifi, decimal media, int N)
        {
            var listaNova = new List<decimal>();
            foreach (var item in listaXifi)
            {
                listaNova.Add(MathCoreApp.Quadrado(Math.Round(item - media, 2)));
            }
            return Math.Round((decimal)(listaNova.Sum() / (N - 1)), 2);
        }


        public MedidasDispersaoEntity Calcular(List<decimal> listaXifi, decimal fiSum, decimal media)
        {
            var variancia = Variancia(listaXifi, media, listaXifi.Count);

            var DP = MathCoreApp.RaizQuadrada(variancia);

            var CV = MathCoreApp.Porcentagem(DP, media);

            return new MedidasDispersaoEntity
            {
                CV = CV,
                Variancia = variancia,
                DP = DP,
            };
        }
        public MedidasDispersaoContainerEntity Build(List<decimal> inputData)
        {
            var media = MathCoreApp.MediaComum(inputData);

            var inputValueQuadrado = MathCoreApp.SomaTodosAoQuadrado(inputData, media);

            var medidasDispersao = Calcular(inputData, inputData.Count(), media);

            return new MedidasDispersaoContainerEntity()
            {
                Media = media,
                Rol = MathCoreApp.Rol(inputData),
                InputValue = inputData,
                InputValueQuadrado = inputValueQuadrado,
                SomaInputValueQuadrado = inputValueQuadrado.Sum(),
                MedidasDispersaoEntity = medidasDispersao
            };
        }
    }
}
