using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;
using EstatisticaFatec.Core.Models.MedidasDispersao;
using EstatisticaFatec.Core.Models.VariavelDiscreta;

namespace EstatisticaFatec.Core.VariavelDiscreta
{
    public class VariavelDiscretaProbabilidade
    {
        private readonly DistribuicaoNormalApp DistribuicaoNormalApp;
        public VariavelDiscretaProbabilidade()
        {
            DistribuicaoNormalApp = new DistribuicaoNormalApp();
        }

        public List<VariavelDiscretaEntity> Build(List<VariavelDiscretaEntity> baseInputs, decimal desvioPadrao, decimal media)
        {

            foreach (var item in baseInputs)
            {
                item.Probabilidade = DistribuicaoNormalApp.Build(new DistribuicaoNormalEntity
                {
                    TipoEntrada = 0,
                    Valor = new decimal?[] {item.FI},
                    DesvioPadrao = desvioPadrao,
                    MediaPonderada = media
                }).Probabilidade;
            }

            return baseInputs;
        }
    }
}