using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.MedidasDispersao;
using EstatisticaFatec.Core.Models.VariavelDiscreta;

namespace EstatisticaFatec.Core.VariavelDiscreta
{
    public class VariavelDiscretaApp
    {
        private XIFIQuadFI PreencherXIFIQUADFI(decimal XI, decimal media, int FI)
        {
            return new XIFIQuadFI
            {
                Formula = $"({XI} - `{media})². {FI}",
                Valor = MathCoreApp.Quadrado((XI - media)) * FI,
            };
        }
        public VariavelDiscretaContainerEntity Build(BaseInputsEntity baseInputs)
        {
            var f = new List<decimal>();
            var fePorcentList = new List<decimal>();
            var listaVariavelDiscreta = new List<VariavelDiscretaEntity>();



            var media = MathCoreApp.MediaComum(baseInputs.InputValue);
            var agrupamento = new AgrupamentoApp().Build(baseInputs.Rol);

            foreach (var item in agrupamento)
            {
                var fePorcent = MathCoreApp.Porcentagem(item.Quantidade, agrupamento.Select(q => q.Quantidade).Sum());

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
                    XIFIQuadFI = PreencherXIFIQUADFI(item.XI, media, item.Quantidade),
                });
            }

            var medidasTendenciaApp = new MedidasTendenciaApp().Calcular(baseInputs.InputValue);

            var variancia = Variancia(listaVariavelDiscreta.Select(q => q.XI).ToList(), listaVariavelDiscreta.Select(q => q.FI).ToList(), media, baseInputs.Amostra);
            var dp = MathCoreApp.RaizQuadrada(variancia);
            var cv = Math.Round((decimal)((dp / media)) * 100, 2);

            var medidasDispersaoApp = new MedidasDispersaoEntity
            {
                Variancia = variancia,
                DP = dp,
                CV = cv
            };

            return new VariavelDiscretaContainerEntity
            {
                InputValue = baseInputs.InputValue,
                Rol = baseInputs.Rol,
                VariavelDiscretaEntity = listaVariavelDiscreta,
                MedidasDispersaoEntity = medidasDispersaoApp,
                MedidasTendenciaEntity = medidasTendenciaApp,
                AgrupamentoEntity = agrupamento
            };
        }

        public static decimal Variancia(List<decimal> listaXI, List<decimal> listaFI, decimal media, bool amostra)
        {
            var N = listaFI.Sum();
            if (amostra)
            {
                N = N - 1;
            }

            var listaNova = new List<decimal>();

            for (int i = 0; i < listaXI.Count; i++)
            {
                var conta = MathCoreApp.Quadrado(Math.Round(listaXI[i] - media, 2));
                listaNova.Add(conta * listaFI[i]);
            }


            var soma = listaNova.Sum();
            return Math.Round((decimal)(soma / (N)), 2);
        }

    }
}