
using System;
using System.Linq;
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
                var valorTabela = TabelaDistribuicao.Calcular(Z);

                entidade.DistribuicaoNormalZEntity.Add(new DistribuicaoNormalZEntity()
                {
                    ValorOriginal = item,
                    Z = Z,
                    ValorTabela = TabelaDistribuicao.Calcular(Z),
                    Probabilidade = Probabilidade(item, valorTabela, entidade)
                });
            }
            entidade.Probabilidade = entidade.DistribuicaoNormalZEntity.Sum(q => q.Probabilidade);
            return entidade;

        }

        private decimal Probabilidade(decimal valorOriginal, decimal valorTabela, DistribuicaoNormalEntity entidade)
        {
            if (entidade.TipoEntrada != 2)
                return Math.Round((valorOriginal > entidade.MediaPonderada ? new decimal(0.5) - valorTabela : valorTabela + new decimal(0.5)) * 100, 2);
            return Math.Round((valorOriginal > entidade.MediaPonderada ? new decimal(0.5) - valorTabela : valorTabela + new decimal(0.5)) * 100, 2);
        }

        private decimal CalcularZ(decimal valor, decimal media, decimal desvioPadrao)
        {
            return Math.Abs(valor - media) / desvioPadrao;
        }

    }
}
