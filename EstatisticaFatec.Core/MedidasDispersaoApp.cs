using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.MedidasDispersao;

namespace EstatisticaFatec.Core
{
    public class MedidasDispersaoApp
    {
        public MedidasDispersaoEntity Build(List<decimal> inputData)
        {
            var media = MathCoreApp.MediaComum(inputData);

            var xiSomaQuadrado = MathCoreApp.SomaTodosAoQuadrado(inputData, media);

            var ExiSomaQuadrado = xiSomaQuadrado.Sum();

            var divisaox1Quadrado = MathCoreApp.DivideV2PorQuantidade(ExiSomaQuadrado, inputData.Count);

            var raizV = MathCoreApp.RaizQuadrada(divisaox1Quadrado);

            var cv = MathCoreApp.Porcentagem(raizV, media);

            return new MedidasDispersaoEntity
            {
                CV = cv,
                Media = media,
                Rol = MathCoreApp.Rol(inputData),
                InputValue = inputData,
                EXIQuadrado = divisaox1Quadrado,
                InputValueQuadrado = xiSomaQuadrado,
                RaizEXIQuadrado = raizV,
                SomaInputValueQuadrado = ExiSomaQuadrado
            };
        }
    }
}
