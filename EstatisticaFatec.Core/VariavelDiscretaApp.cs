using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.MedidasDispersao;
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
                    FPorcent = fePorcentList.Sum(),
                    XIFI = item.XI * item.Quantidade,
                    XIFIQuadFI = PreencherXIFIQUADFI(item.XI, media, item.Quantidade)
                });
            }

            var medidasTendenciaApp = new MedidasTendenciaApp().Calcular(inputData);

            var variancia = MedidasDispersaoApp.Variancia(listaVariavelDiscreta.Select(q => q.XI).ToList(), media, listaVariavelDiscreta.Select(q => q.XI).Count());
            var dp = RaizQuadrada(variancia);
            var cv = Math.Round((decimal)((dp / media)) * 100, 2);

            var medidasDispersaoApp = new MedidasDispersaoEntity
            {
                Variancia = variancia,
                DP = dp,
                CV = cv

            };


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