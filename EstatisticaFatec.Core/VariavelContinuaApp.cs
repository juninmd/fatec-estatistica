using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.MedidasDispersao;
using EstatisticaFatec.Core.Models.MedidasTendencia;
using EstatisticaFatec.Core.Models.VariavelContinua;
using static EstatisticaFatec.Core.MathCoreApp;

namespace EstatisticaFatec.Core
{
    public class VariavelContinuaApp
    {

        public static decimal VarianciaContinua(List<decimal> listaXi, List<decimal> listaFi, decimal media, decimal N, bool amostra = true)
        {
            if (amostra)
            {
                N = N - 1;
            }
            var listaNova = new List<decimal>();


            for (int i = 0; i < listaXi.Count; i++)
            {
                var conta = MathCoreApp.Quadrado(Math.Round(listaXi[i] - media, 2)) * listaFi[i];
                listaNova.Add(conta);

            }
            var soma = listaNova.Sum();

            return Math.Round((decimal)(soma / (N)), 2);
        }

        private static decimal MedianaQuantitativa(List<VariavelContinuaEntity> listaTabelaQuantitativa, decimal IC)
        {
            var soma = listaTabelaQuantitativa.Sum(q => q.FI);

            var posicao = soma / 2;

            var classe = listaTabelaQuantitativa.Where(q => posicao < q.F).OrderByDescending(p => p.F).ToList().First();
            var indexClasseAnterior = classe.Classe - 1;
            var fant = listaTabelaQuantitativa.FirstOrDefault(q => q.Classe == indexClasseAnterior)?.F ?? 0;

            var I = classe.Range[0];
            var EFI = soma;
            var Fant = fant;
            var FIND = classe.FI;
            var H = IC;

            return I + ((((decimal)((decimal)EFI / 2) - Fant) / FIND) * H);


        }

        private static decimal[] ModaQuantitativa(List<VariavelContinuaEntity> listaTabelaQuantitativa)
        {
            var maxFi = listaTabelaQuantitativa.Max(q => q.FI);
            var listaPossivelModa = listaTabelaQuantitativa.Where(q => q.FI == maxFi);

            return listaPossivelModa.Select(q => q.XI).ToArray();
        }


        private VariavelContinuaIcEntity GetIC(decimal al, List<decimal> K)
        {
            while (true)
            {
                /* K  - 1 */
                if (K[0] != 0 && al / K[0] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[0]),
                        Classes = (int)K[0]
                    };
                }
                /* K */
                if (K[1] != 0 && al / K[1] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[1]),
                        Classes = (int)K[1]
                    };
                }
                /* K + 1*/
                if (K[2] != 0 && al / K[2] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[2]),
                        Classes = (int)K[2]
                    };
                }
                al++;
            }
        }

        public VariavelContinuaContainerEntity Build(List<decimal> inputData)
        {
            var rol = Rol(inputData);
            var media = MediaComum(inputData);
            var xMAx = inputData.Max();
            var xMin = inputData.Min();

            var al = (xMAx - xMin);

            var numeroPreK = (int)Math.Sqrt(inputData.Count());
            var K = new List<decimal> { numeroPreK - 1, numeroPreK, numeroPreK + 1 };

            var Ic = GetIC(al, K);


            var minimo = xMin;
            var maximo = minimo + (int)Ic.IC;

            var f = new List<int>();
            var fePorcentList = new List<decimal>();

            var listaTabelaQuantitativa = new List<VariavelContinuaEntity>();

            for (int i = 1; i <= Ic.Classes; i++)
            {
                var fePorcent = (decimal)(rol.Count(x => x >= minimo && x < maximo) / (decimal)rol.Count()) * 100;
                var count = rol.Count(x => x >= minimo && x < maximo);

                f.Add(count);
                fePorcentList.Add(fePorcent);

                var xi = Mediana(new List<decimal>() { minimo, maximo });

                listaTabelaQuantitativa.Add(new VariavelContinuaEntity
                {
                    Classe = i,
                    Range = new[] { minimo, maximo },
                    FI = count,
                    FEPorcent = Math.Round(fePorcent, 2),
                    F = f.Sum(),
                    FPorcent = Math.Round(fePorcentList.Sum(), 2),
                    XI = xi,
                    XIFI = xi * count,
                });

                minimo = maximo;
                maximo = maximo + (int)Ic.IC;
            }

            var variancia = VarianciaContinua(listaTabelaQuantitativa.Select(q => q.XI).ToList(), listaTabelaQuantitativa.Select(x => x.FI).ToList(), media, listaTabelaQuantitativa.Sum(y => y.FI));
            var dp = MathCoreApp.RaizQuadrada(variancia);
            var cv = MathCoreApp.Porcentagem(dp, media);

            var medidasDispersao = new MedidasDispersaoEntity
            {
                Variancia = variancia,
                DP = dp,
                CV = cv
            };

            var medidasTendencia = new MedidasTendenciaEntity
            {
                Media = MediaComum(inputData),
                Mediana = MedianaQuantitativa(listaTabelaQuantitativa, Ic.IC),
                Moda = ModaQuantitativa(listaTabelaQuantitativa)
            };

            return new VariavelContinuaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelContinuaEntity = listaTabelaQuantitativa,
                MinLinha = xMin,
                MaxLinha = xMAx,
                AL = al,
                K = K,
                IC = Ic,
                MedidasDispersaoEntity = medidasDispersao,
                MedidasTendenciaEntity = medidasTendencia,
                EXIFI = listaTabelaQuantitativa.Sum(entity => entity.XIFI),
                EFI = listaTabelaQuantitativa.Sum(entity => entity.FI),
            };
        }

    }
}