using System;
using EstatisticaFatec.Core.Models.DistribuicaoUniforme;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoUniformeApp
    {
        public DistribuicaoUniformeEntity Build(DistribuicaoUniformeEntity entidade)
        {
            entidade.Media = (entidade.B + entidade.A) / 2;
            entidade.DesvioPadrao = (decimal)Math.Sqrt(Math.Pow((double)(entidade.B - entidade.A), 2) / 2);
            entidade.Probabilidade = (1 / (entidade.B - entidade.A)) * entidade.X;
            return new DistribuicaoUniformeEntity();
        }
    }
}
