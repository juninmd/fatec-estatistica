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
                        Classes = al
                    };
                }
                /* K */
                if (al / K[1] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[0]),
                        Classes = al
                    };
                }
                /* K + 1*/
                if (al / K[2] % 2 == 0)
                {
                    return new VariavelContinuaIcEntity
                    {
                        IC = (al / K[0]),
                        Classes = al
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

            var K = new List<decimal> { inputData.Count(), inputData.Count() + 1, inputData.Count() - 1 };

            var Ic = GetIC(al, K);

            var listaTabelaQuantitativa = new List<VariavelContinuaEntity>();


            var f = new List<int>();
            var fePorcent = new List<decimal>();

           /* for (int i = 0; i < Ic.Classes; i++)
            {
                f.Add(item.Count());
                fePorcent.Add((item.Count() / (decimal)listaGrupos.Select(q => q.Count()).Sum()) * 100);

                listaTabelaQuantitativa.Add(new VariavelContinuaEntity
                {
                    XI = item.Key,
                    FI = item.Count(),
                    FEPorcent = (item.Count() / (decimal)listaGrupos.Select(q => q.Count()).Sum()) * 100,
                    F = f.Sum(),
                    FPorcent = fePorcent.Sum()

                });
            }*/

 

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