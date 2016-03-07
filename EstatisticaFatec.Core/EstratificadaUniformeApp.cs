using System;
using EstatisticaFatec.Core.Models.EstratificadaUniforme;

namespace EstatisticaFatec.Core
{
    public class EstratificadaUniformeApp
    {
        public EstratificadaUniformeEntity Build(int amostra, int estratos)
        {
            return new EstratificadaUniformeEntity
            {
                QtdEstrato = estratos,
                Amostra = amostra,
                Resultado = Math.Round((decimal)(amostra / estratos))
            };
        }
    }
}