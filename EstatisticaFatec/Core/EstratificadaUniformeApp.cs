using System;

namespace EstatisticaFatec.Core
{
    public class EstratificadaUniformeApp
    {
        public decimal Build(int amostra, int estratos)
        {
            return Math.Round((decimal) (amostra / estratos));
        }
    }
}