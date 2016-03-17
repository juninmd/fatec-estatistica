using System.Collections.Generic;
using EstatisticaFatec.Core.Models.MedidasTendencia;

namespace EstatisticaFatec.Core
{
    public class MedidasTendenciaApp
    {
        public MedidasTendenciaEntity Build(List<decimal> inputData)
        {
            return new MedidasTendenciaEntity
            {
                InputValue = inputData,
                Rol = MathCoreApp.Rol(inputData),
                Media = MathCoreApp.MediaComum(inputData),
                Mediana = MathCoreApp.Mediana(inputData),
                Moda = MathCoreApp.Moda(inputData)
            };
        }
    }
}
