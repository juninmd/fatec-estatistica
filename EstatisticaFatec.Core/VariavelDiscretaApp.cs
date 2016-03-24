using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.VariavelQuantitativa;
using static EstatisticaFatec.Core.MathCoreApp;

namespace EstatisticaFatec.Core
{
    public class VariavelDiscretaApp
    {
        private decimal DP(decimal variancia)
        {
            return RaizQuadrada(variancia);
        }
        private decimal Variancia(decimal xifi, decimal FISUM)
        {
            return Math.Round(xifi / FISUM,2);
        }
        private XIFIQuadFI PreencherXIFIQUADFI(decimal XI, decimal media, int FI)
        {
            return new XIFIQuadFI
            {
                Formula = $"({XI} - `{media})². {FI}",
                Valor = Quadrado((XI - media)) * FI,
            };
        }
        public VariavelDiscretaContainerEntity Build(List<decimal> inputData)
        {
            var rol = Rol(inputData);

            var media = MediaComum(inputData);

            var listaGrupos = rol.GroupBy(x => x);
 

            var f = new List<decimal>();

            var fePorcentList = new List<decimal>();

            var listaVariavelDiscreta = new List<VariavelQuantitativaEntity>();

            foreach (var item in listaGrupos)
            {
                var fePorcent = Porcentagem(item.Count(), listaGrupos.Select(q => q.Count()).Sum());

                f.Add(item.Count());
                fePorcentList.Add(fePorcent);

                listaVariavelDiscreta.Add(new VariavelQuantitativaEntity
                {
                    XI = item.Key,
                    FI = item.Count(),
                    FEPorcent = Math.Round(fePorcent, 2),
                    F = f.Sum(),
                    FPorcent = Math.Round(fePorcentList.Sum(), 2),
                    XIFI = item.Key * item.Count(),
                    XIFIQuadFI = PreencherXIFIQUADFI(item.Key, media, item.Count())
                });
            }

            var variancia = Variancia(listaVariavelDiscreta.Select(q => q.XIFIQuadFI.Valor).Sum(), listaVariavelDiscreta.Select(e => e.FI).Sum());
            var dp = DP(variancia);
            var cv = Porcentagem(dp, media);

            return new VariavelDiscretaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelQuantitativaEntity = listaVariavelDiscreta,
                Moda = Moda(inputData),
                Media = media,
                Mediana = Mediana(rol),
                Variancia = variancia,
                DP = dp,
                CV = cv
            };
        }
    }
}