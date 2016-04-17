﻿
using System;
using EstatisticaFatec.Core.Const;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoNormalApp
    {
        public DistribuicaoNormalApp()
        {
            TabelaDistribuicao = new TabelaDistribuicao();
        }
        public TabelaDistribuicao TabelaDistribuicao { get; set; }
        public DistribuicaoNormalEntity Build(DistribuicaoNormalEntity entidade)
        {
            foreach (var item in entidade.Valor)
            {
                var Z = CalcularZ(item, entidade.MediaPonderada, entidade.DesvioPadrao);
                entidade.DistribuicaoNormalZEntity.Add(new DistribuicaoNormalZEntity()
                {
                    ValorOriginal = item,
                    Z = Z,
                    ValorTabela = TabelaDistribuicao.Calcular(Z),
                    IsBigger = item > entidade.MediaPonderada
                });
            }
            return entidade;

        }

        private decimal CalcularZ(decimal valor, decimal media, decimal desvioPadrao)
        {
            return Math.Abs(valor - media) / desvioPadrao;
        }
       
    }
}
