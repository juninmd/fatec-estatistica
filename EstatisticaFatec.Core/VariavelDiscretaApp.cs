using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.VariavelDiscreta;
using static EstatisticaFatec.Core.MathCoreApp;

namespace EstatisticaFatec.Core
{
    public class VariavelDiscretaApp
    {
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
            var f = new List<decimal>();
            var fePorcentList = new List<decimal>();
            var listaVariavelDiscreta = new List<VariavelDiscretaEntity>();


            var rol = Rol(inputData);
            var media = MediaComum(inputData);
            var agrupamento = new AgrupamentoApp().Build(rol);

            foreach (var item in agrupamento)
            {
                var fePorcent = Porcentagem(item.Quantidade, agrupamento.Select(q => q.Quantidade).Sum());

                f.Add(item.Quantidade);
                fePorcentList.Add(fePorcent);

                listaVariavelDiscreta.Add(new VariavelDiscretaEntity
                {
                    XI = item.XI,
                    FI = item.Quantidade,
                    FEPorcent = Math.Round(fePorcent, 2),
                    F = f.Sum(),
                    FPorcent = Math.Round(fePorcentList.Sum(), 2),
                    XIFI = item.XI * item.Quantidade,
                    XIFIQuadFI = PreencherXIFIQUADFI(item.XI, media, item.Quantidade)
                });
            }

            var medidasDispersaoApp = new MedidasDispersaoApp().Calcular(listaVariavelDiscreta.Select(q => q.XIFIQuadFI.Valor).Sum(), media, listaVariavelDiscreta.Select(e => e.FI).Sum());
            var medidasTendenciaApp = new MedidasTendenciaApp().Calcular(inputData);


            return new VariavelDiscretaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelDiscretaEntity = listaVariavelDiscreta,
                MedidasDispersaoEntity = medidasDispersaoApp,
                MedidasTendenciaEntity = medidasTendenciaApp,
                AgrupamentoEntity = agrupamento
            };
        }
    }
}