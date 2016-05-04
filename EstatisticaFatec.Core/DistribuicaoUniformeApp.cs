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
            entidade.X = Intervalo(entidade.Input);
            entidade.Probabilidade = ((decimal)1 / (entidade.B - entidade.A)) * entidade.X;
            return entidade;
        }

        private decimal Intervalo(decimal[] input)
        {
            return input.Max() - input.Min();
        }
    }
}
