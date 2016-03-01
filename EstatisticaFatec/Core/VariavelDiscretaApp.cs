using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Models;
using EstatisticaFatec.Models.VariavelQuantitativa;

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
                    FPorcent = Math.Round(fePorcentList.Sum(), 2)

                });
            }

            return new VariavelDiscretaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelQuantitativaEntity = listaTabelaQuantitativa

            };
        }
    }
}