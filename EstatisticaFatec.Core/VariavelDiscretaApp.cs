using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Core
{
    public class VariavelDiscretaApp
    {
        public VariavelDiscretaContainerEntity Build(List<decimal> inputData)
        {
            var rol = MathCoreApp.Rol(inputData);

            var listaTabelaQuantitativa = new List<VariavelQuantitativaEntity>();

            var listaGrupos = rol.GroupBy(x => x);

            var f = new List<decimal>();
            var fePorcentList = new List<decimal>();

            var media = MathCoreApp.MediaComum(inputData);

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
                    XIFI = item.Key * item.Count(),
                    XIFIQuadFI = (item.Key - media) * item.Count(),

                });
            }

            return new VariavelDiscretaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelQuantitativaEntity = listaTabelaQuantitativa,
                Moda = MathCoreApp.Moda(inputData),
                Media = media,
                Mediana = MathCoreApp.Mediana(rol)

            };
        }
    }
}