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

            if (entidade.TipoEntrada != -1)
            {
                entidade.X = entidade.TipoEntrada == -1 ? null : Intervalo(entidade.Input);
                entidade.Probabilidade = entidade.TipoEntrada == -1 ? (decimal?)null : (decimal)(((decimal)1 / (entidade.B - entidade.A)) * entidade.X) * 100;
            }
         
            return entidade;
        }

        private decimal? Intervalo(decimal?[] input)
        {
            return input?.Max() - input?.Min();
        }
    }
}
