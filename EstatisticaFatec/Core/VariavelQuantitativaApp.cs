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
            var fePorcentList = new List<decimal>();

            foreach (var item in listaGrupos)
            {
                var fePorcent = (item.Count()/(decimal) listaGrupos.Select(q => q.Count()).Sum())*100;

                f.Add(item.Count());
                fePorcentList.Add(fePorcent);

                listaTabelaQuantitativa.Add(new VariavelQuantitativaEntity
                {
                    XI = item.Key,
                    FI = item.Count(),
                    FEPorcent = fePorcent,
                    F = f.Sum(),
                    FPorcent = fePorcentList.Sum()

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