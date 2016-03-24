using EstatisticaFatec.Core.Models.EstratificadaUniforme;
using System;
using EstatisticaFatec.Core.Models;

namespace EstatisticaFatec.Core
{
    public class EstratificadaUniformeApp
    {
        public RequestMessage ValidateInput(int amostra, int estratos)
        {
            return new RequestMessage
            {
                IsError = amostra > estratos,
                Message = "A amostra não pode ser maior que os estratos."
            };
        }
        public EstratificadaUniformeEntity Build(int amostra, int estratos)
        {
            return new EstratificadaUniformeEntity
            {
                QtdEstrato = estratos,
                Amostra = amostra,
                Resultado = (decimal)Math.Round((decimal)((decimal)amostra / (decimal)estratos))
            };
        }
    }
}