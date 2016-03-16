using System;
using System.Collections.Generic;
using System.Linq;
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
                Rol = inputData.OrderBy(q=> q).ToList(),
                Media = Math.Round((decimal)inputData.Sum() / (decimal)inputData.Count, 2),
                Mediana = MathCoreApp.Mediana(inputData.OrderBy(q => q).ToList()),
                Moda = (from item in inputData
                               group item by item into g
                               orderby g.Count() descending
                               select g.Key).First(),
            };
        }
    }
}
