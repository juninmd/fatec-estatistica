using System.Collections.Generic;
using EstatisticaFatec.Core.Models.MedidasTendencia;

namespace EstatisticaFatec.Core
{
    /// <summary>
    /// <para>Classe responsável por calcular</para>
    /// <para> Média | Moda | Mediana</para>
    /// </summary>
    public class MedidasTendenciaApp
    {
        public MedidasTendenciaContainerEntity Build(List<decimal> inputData)
        {
            return new MedidasTendenciaContainerEntity()
            {
                InputValue = inputData,
                Rol = MathCoreApp.Rol(inputData),
                MedidasTendenciaEntity = Calcular(inputData),
            };
        }
     
        public MedidasTendenciaEntity Calcular(List<decimal> inputData)
        {
            return new MedidasTendenciaEntity
            {
                Media = MathCoreApp.MediaComum(inputData),
                Mediana = MathCoreApp.Mediana(inputData),
                Moda = MathCoreApp.Moda(inputData)
            };
        }
    }
}
