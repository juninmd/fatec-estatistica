﻿using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.VariavelContinua;

namespace EstatisticaFatec.Core
{
    public class VariavelContinuaApp
    {
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
            var rol = MathCoreApp.Rol(inputData);

            var xMAx = inputData.Max();
            var xMin = inputData.Min();

            var al = xMAx - xMin + 1;

            var numeroPreK = (int)Math.Sqrt(inputData.Count());
            var K = new List<decimal> { numeroPreK - 1, numeroPreK, numeroPreK + 1 };

            var Ic = GetIC(al, K);

            var listaTabelaQuantitativa = new List<VariavelContinuaEntity>();

            var minimo = xMin;
            var maximo = minimo + (int)Ic.IC;

            var f = new List<int>();
            var fePorcentList = new List<decimal>();
            for (int i = 1; i <= Ic.Classes; i++)
            {
                var fePorcent = (decimal)(rol.Count(x => x >= minimo && x < maximo) / (decimal)rol.Count()) * 100;
                var count = rol.Count(x => x >= minimo && x < maximo);

                f.Add(count);
                fePorcentList.Add(fePorcent);

                var xi = MathCoreApp.Mediana(new List<decimal>() {minimo, maximo});

                listaTabelaQuantitativa.Add(new VariavelContinuaEntity
                {
                    Classe = i,
                    Range = new[] { minimo, maximo },
                    Count = count,
                    FEPorcent = Math.Round(fePorcent, 2),
                    F = f.Sum(),
                    FPorcent = Math.Round(fePorcentList.Sum(), 2),
                    XI = xi,
                    Media = xi * count
                });

                minimo = maximo;
                maximo = maximo + (int)Ic.IC;
            }

            return new VariavelContinuaContainerEntity
            {
                InputValue = inputData,
                Rol = rol,
                VariavelContinuaEntity = listaTabelaQuantitativa,
                MinLinha = xMin,
                MaxLinha = xMAx,
                AL = al,
                K = K,
                IC = Ic.Classes,
                Moda = ModaQuantitativa(listaTabelaQuantitativa),
                Media = MathCoreApp.MediaComum(inputData),
                Mediana = MathCoreApp.Mediana(rol),
                EXIFI = listaTabelaQuantitativa.Sum(entity => entity.Media),
                EFI = listaTabelaQuantitativa.Sum(entity => entity.Count),

            };
        }
        public static decimal ModaQuantitativa(List<VariavelContinuaEntity> listaTabelaQuantitativa)
        {
            var maximo = (listaTabelaQuantitativa.Max(q => q.Count));
            var counts = listaTabelaQuantitativa.Where(g => g.Count == maximo).Select(q => q.Range);

            var decimalMEdia = new decimal(0) + counts.Sum(item => (item[0] + item[1])/2);
            return decimalMEdia/counts.Count();
        }

        public static decimal MedianaQuantitativa(List<VariavelContinuaEntity> listaTabelaQuantitativa)
        {
            var maximo = (listaTabelaQuantitativa.Max(q => q.Count));
            var counts = listaTabelaQuantitativa.Where(g => g.Count == maximo).Select(q => q.Range);

            var decimalMEdia = new decimal(0) + counts.Sum(item => (item[0] + item[1]) / 2);
            return decimalMEdia / counts.Count();
        }
    }
}