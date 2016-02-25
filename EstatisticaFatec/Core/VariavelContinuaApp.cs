using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Models.VariavelContinua;
using EstatisticaFatec.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Core
{
    public class VariavelContinuaApp
    {
        private VariavelContinuaIcEntity GetIC(int al, List<decimal> K)
        {
            while (true)
            {
                /* K  - 1 */
                if (al / K[0] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[0]),
                        Classes = (int)K[0]
                    };
                }
                /* K */
                if (al / K[1] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[1]),
                        Classes = (int)K[1]
                    };
                }
                /* K + 1*/
                if (al / K[2] % 2 == 0)
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
        public VariavelContinuaContainerEntity Build(List<int> inputData)
        {
            var rol = inputData.OrderBy(x => x).ToList();

            var xMAx = inputData.Max();
            var xMin = inputData.Min();

            var al = xMAx - xMin + 1;

            var numeroPreK = (int)Math.Sqrt(inputData.Count());
            var K = new List<decimal> { numeroPreK - 1, numeroPreK, numeroPreK + 1 };

            var Ic = GetIC(al, K);

            var listaTabelaQuantitativa = new List<VariavelContinuaEntity>();

            var minimo = xMin;
            var maximo = minimo + (int)Ic.IC;

            for (int i = 1; i <= Ic.Classes; i++)
            {
             
                listaTabelaQuantitativa.Add(new VariavelContinuaEntity
                {
                    Classe = i,
                    Count = new int[2] { minimo, maximo },
                    F = rol.Where(x => x >= minimo && x < maximo).GroupBy(q => q).Count()
                });

                minimo = maximo;
                maximo = maximo + (int) Ic.IC;

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
                IC = Ic.Classes
            };
        }
    }
}