using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.VariavelContinua;
using static EstatisticaFatec.Core.MathCoreApp;

namespace EstatisticaFatec.Core
{
    public class VariavelContinuaApp
    {
        private decimal DP(decimal variancia)
        {
            return RaizQuadrada(variancia);
        }
        private decimal Variancia(decimal xifi, decimal FISUM)
        {
            return xifi / FISUM;
        }

        private static decimal ModaQuantitativa(List<VariavelContinuaEntity> listaTabelaQuantitativa)
        {
            var maximo = (listaTabelaQuantitativa.Max(q => q.FI));
            var counts = listaTabelaQuantitativa.Where(g => g.FI == maximo).Select(q => q.Range);

            var decimalMEdia = new decimal(0) + counts.Sum(item => (item[0] + item[1]) / 2);
            return decimalMEdia / counts.Count();
        }

        private static decimal MedianaQuantitativa(List<VariavelContinuaEntity> listaTabelaQuantitativa, decimal IC)
        {
            var soma = listaTabelaQuantitativa.Sum(q => q.FI);

            var posicao = soma / 2;

            var classe = listaTabelaQuantitativa.Where(q => q.F > posicao).OrderBy(p => p.F).ToList().First();
            var classeAnterior = listaTabelaQuantitativa.Where(q => q.F < posicao).OrderByDescending(q => q.F).First();

            var I = classe.Range[0];
            var EFI = soma;
            var Fant = classeAnterior.F;
            var FIND = classe.FI;
            var H = IC;

            return I + Math.Round((decimal)((EFI / 2) - Fant) / FIND * H, 2);
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

            var al = (xMAx - xMin) + 1;

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


            var variancia = Variancia(listaTabelaQuantitativa.Select(q => q.XIFI).Sum(), listaTabelaQuantitativa.Select(e => e.FI).Sum());
            var dp = DP(variancia);
            var cv = Porcentagem(dp, media);

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
                Moda = Moda(inputData),
                Media = media,
                Mediana = MedianaQuantitativa(listaTabelaQuantitativa,Ic.IC),
                EXIFI = listaTabelaQuantitativa.Sum(entity => entity.XIFI),
                EFI = listaTabelaQuantitativa.Sum(entity => entity.FI),
                Variancia = variancia,
                CV = cv,
                DP = dp,

            };
        }

    }
}