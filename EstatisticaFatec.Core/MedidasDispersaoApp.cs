using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models;
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
        /// <param name="media"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static decimal Variancia(List<decimal> listaXI, decimal media, int N, bool amostra = true)
        {
            if (amostra)
            {
                N = N - 1;
            }

            var listaNova = new List<decimal>();
            foreach (var item in listaXI)
            {
                listaNova.Add(MathCoreApp.Quadrado(Math.Round(item - media, 2)));
            }

            var soma = listaNova.Sum();
            return Math.Round((decimal)(soma / (N)), 2);
        }


        public MedidasDispersaoEntity Calcular(List<decimal> listaXifi, decimal media)
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
        public MedidasDispersaoContainerEntity Build(BaseInputsEntity baseInputs)
        {
            var media = MathCoreApp.MediaComum(baseInputs.InputValue);

            var inputValueQuadrado = MathCoreApp.SomaTodosAoQuadrado(baseInputs.InputValue, media);

            var medidasDispersao = Calcular(baseInputs.InputValue, media);

            return new MedidasDispersaoContainerEntity()
            {
                Media = media,
                Rol = baseInputs.Rol,
                InputValue = baseInputs.InputValue,
                InputValueQuadrado = inputValueQuadrado,
                SomaInputValueQuadrado = inputValueQuadrado.Sum(),
                MedidasDispersaoEntity = medidasDispersao
            };
        }
    }
}
