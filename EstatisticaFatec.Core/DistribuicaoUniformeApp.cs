using System;
using System.Linq;
using EstatisticaFatec.Core.Models.DistribuicaoUniforme;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoUniformeApp
    {
        public DistribuicaoUniformeEntity Build(DistribuicaoUniformeEntity entidade)
        {
            entidade.Media = (entidade.B + entidade.A) / 2;
            entidade.DesvioPadrao = Math.Round((decimal)Math.Sqrt(Math.Pow((double)(entidade.B - entidade.A), 2) / 12), 2);
            entidade.Variancia = Math.Round(MathCoreApp.Quadrado(entidade.DesvioPadrao),2);

            if (entidade.TipoEntrada != -1)
            {
                entidade.X = CalcularX(entidade);
                entidade.Probabilidade = (decimal)(((decimal) entidade.X / (entidade.B - entidade.A)) ) * 100;
            }

            return entidade;
        }

        private decimal CalcularX(DistribuicaoUniformeEntity entidade)
        {
            switch (entidade.TipoEntrada)
            {
                // Menor 
                case 0:
                    return entidade.Input[0].Value - entidade.A;

                // Entre
                case 1:
                    return Intervalo(entidade.Input).Value;

                // Maior
                case 2:
                    return entidade.B - entidade.Input[0].Value;

                // Exatamente
                case 3:
                    return entidade.Input[0].Value;
            }
            return 0;
        }

        private decimal? Intervalo(decimal?[] input)
        {
            return input?.Max() - input?.Min();
        }
    }
}
