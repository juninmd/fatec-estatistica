using System;

namespace EstatisticaFatec.Core
{
    public class ProbabilidadeApp
    {
        public decimal Build(decimal amostra, decimal populacao)
        {
            return Math.Round(amostra / populacao, 2);
        }
    }
}
