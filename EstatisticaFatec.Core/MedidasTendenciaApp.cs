using System.Collections.Generic;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.MedidasTendencia;

namespace EstatisticaFatec.Core
{
    /// <summary>
    /// <para>Classe responsável por calcular</para>
    /// <para> Média | Moda | Mediana</para>
    /// </summary>
    public class MedidasTendenciaApp
    {
        public MedidasTendenciaContainerEntity Build(BaseInputsEntity baseInputs)
        {
            return new MedidasTendenciaContainerEntity()
            {
                InputValue = baseInputs.InputValue,
                Rol = baseInputs.Rol,
                MedidasTendenciaEntity = Calcular(baseInputs.InputValue),
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
