using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Models;
using EstatisticaFatec.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Core
{
    public class VariavelQuantitativaApp
    {
        public VariavelQuantitativaContainerEntity Build(List<int> inputData)
        {
            var rol = inputData.OrderBy(x => x).ToList();

            var listaTabelaQuantitativa = new List<VariavelQuantitativaEntity>();

            var listaGrupos = rol.GroupBy(x => x);

            var f = new List<int>();
            var fePorcent = new List<decimal>();

            foreach (var item in listaGrupos)
            {
                f.Add(item.Count());
                fePorcent.Add((item.Count() / (decimal)listaGrupos.Select(q => q.Count()).Sum()) * 100);

                listaTabelaQuantitativa.Add(new VariavelQuantitativaEntity
                {
                    XI = item.Key,
                    FI = item.Count(),
                    FEPorcent = (item.Count() / (decimal)listaGrupos.Select(q => q.Count()).Sum()) * 100,
                    F = f.Sum(),
                    FPorcent = fePorcent.Sum()

                });
            }

           return new VariavelQuantitativaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelQuantitativaEntity = listaTabelaQuantitativa

            };
        }
    }
}