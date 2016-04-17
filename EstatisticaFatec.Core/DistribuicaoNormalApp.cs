
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

        private decimal CalcularZ(decimal valor, decimal media, decimal desvioPadrao)
        {
            return (valor - media) / desvioPadrao;
        }

        public DistribuicaoNormalEntity Build(DistribuicaoNormalEntity entidade)
        {
            foreach (var item in entidade.Valor.Where(q=> q.HasValue))
            {
                var Z = CalcularZ(item.Value, entidade.MediaPonderada, entidade.DesvioPadrao);

                entidade.DistribuicaoNormalZEntity.Add(new DistribuicaoNormalZEntity()
                {
                    ValorOriginal = item.Value,
                    Z = Z,
                    ValorTabela = TabelaDistribuicao.Calcular(Z),
                });
            }

            if (entidade.TipoEntrada == 0)
            {
                var first = entidade.DistribuicaoNormalZEntity.First();
                entidade.Probabilidade = ProbabilidadeMenor(first.Z, first.ValorTabela);
            }
            else if (entidade.TipoEntrada == 1)
            {
                var menor = entidade.DistribuicaoNormalZEntity.First(e => e.Z == entidade.DistribuicaoNormalZEntity.Min(q => q.Z));
                var maior = entidade.DistribuicaoNormalZEntity.First(e => e.Z == entidade.DistribuicaoNormalZEntity.Max(q => q.Z));
                entidade.Probabilidade = ProbabilidadeEntre(new Tuple<decimal, decimal>(menor.Z, menor.ValorTabela), new Tuple<decimal, decimal>(maior.Z, maior.ValorTabela));
            }
            else
            {
                var first = entidade.DistribuicaoNormalZEntity.First();
                entidade.Probabilidade = ProbabilidadeMaior(first.Z, first.ValorTabela);
            }
            return entidade;

        }

        private decimal ProbabilidadeMenor(decimal Z, decimal valorTabela)
        {
            return Math.Round((Z > 0 ? new decimal(0.5) - valorTabela : valorTabela + new decimal(0.5)) * 100, 2);
        }
        private decimal ProbabilidadeEntre(Tuple<decimal, decimal> valorMenor, Tuple<decimal, decimal> valorMaior)
        {
            //<<
            if (valorMenor.Item1 <= 0 && valorMaior.Item1 <= 0)
            {
                if(valorMaior.Item2 < valorMenor.Item2)
                    return Math.Round((valorMenor.Item2 - valorMaior.Item2) * 100, 2);
                return Math.Round((valorMaior.Item2 - valorMenor.Item2) * 100, 2);
            }
            // < >
            else if (valorMenor.Item1 <= 0 && valorMaior.Item1 >= 0)
            {
                return Math.Round((valorMenor.Item2 + valorMaior.Item2) * 100, 2);
            }
            // >>
            else // if (valorMenor >= entidade.MediaPonderada && valorMaior >= entidade.MediaPonderada)
            {
                return Math.Round((valorMaior.Item2 - valorMenor.Item2) * 100, 2);
            }
        }
        private decimal ProbabilidadeMaior(decimal Z, decimal valorTabela)
        {
            return Math.Round((Z > 0 ? new decimal(0.5) - valorTabela : valorTabela + new decimal(0.5)) * 100, 2);

        }
    }
}
