using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Core
{
    public class VariavelDiscretaApp
    {
        public VariavelDiscretaContainerEntity Build(List<int> inputData)
        {
            var rol = inputData.OrderBy(x => x).ToList();

            var listaTabelaQuantitativa = new List<VariavelQuantitativaEntity>();

            var listaGrupos = rol.GroupBy(x => x);

            var f = new List<int>();
            var fePorcentList = new List<decimal>();

            foreach (var item in listaGrupos)
            {
                var fePorcent = (item.Count() / (decimal)listaGrupos.Select(q => q.Count()).Sum()) * 100;

                f.Add(item.Count());
                fePorcentList.Add(fePorcent);

                listaTabelaQuantitativa.Add(new VariavelQuantitativaEntity
                {
                    XI = item.Key,
                    FI = item.Count(),
                    FEPorcent = Math.Round(fePorcent, 2),
                    F = f.Sum(),
                    FPorcent = Math.Round(fePorcentList.Sum(), 2),
                    Media = item.Key * item.Count()

                });
            }

            return new VariavelDiscretaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelQuantitativaEntity = listaTabelaQuantitativa,
                Moda = (from item in inputData
                        group item by item into g
                        orderby g.Count() descending
                        select g.Key).First(),
                Media = Math.Round((decimal)inputData.Sum() / (decimal)inputData.Count, 2),
                Mediana = MathCoreApp.Mediana(rol)

            };
        }
    }
}