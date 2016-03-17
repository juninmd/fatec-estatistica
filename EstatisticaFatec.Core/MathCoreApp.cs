using System;
using System.Collections.Generic;
using System.Linq;

namespace EstatisticaFatec.Core
{
    public static class MathCoreApp
    {
        public static int Mediana(List<int> rol)
        {
            var meuArray = rol.ToArray();

            if ((rol.Count + 1) % 2 == 0)
            {
                return meuArray[((rol.Count + 1) / 2) - 1];
            }
            else if (rol.Count == 2)
            {
                return (meuArray[0] + meuArray[1]) / 2;
            }
            else if (rol.Count == 1)
            {
                return (meuArray[0]);
            }
            else
            {
                var max = meuArray[(rol.Count / 2)];
                var min = meuArray[(rol.Count / 2) - 2];
                return (max + min) / 2;
            }
        }
        public static decimal Mediana(List<decimal> rol)
        {
            rol = Rol(rol);
            var meuArray = rol.ToArray();

            if ((rol.Count + 1) % 2 == 0)
            {
                return meuArray[((rol.Count + 1) / 2) - 1];
            }
            else if (rol.Count == 2)
            {
                return (meuArray[0] + meuArray[1]) / 2;
            }
            else if (rol.Count == 1)
            {
                return (meuArray[0]);
            }
            else
            {
                var max = meuArray[(rol.Count / 2)];
                var min = meuArray[(rol.Count / 2) - 2];
                return (max + min) / 2;
            }
        }
        public static decimal[] Moda(List<decimal> inputData)
        {
            var maximo = (inputData.GroupBy(item => item).Select(g => g.Count())).Max();
            return (inputData.GroupBy(item => item).Where(g => g.Count() == maximo)).Select(q => q.Key).ToArray();
        }

        public static decimal MediaComum(List<decimal> inputData)
        {
            return Math.Round((decimal) inputData.Sum()/(decimal) inputData.Count, 2);
        }

        public static List<decimal> Rol(List<decimal> inputData)
        {
            return inputData.OrderBy(q => q).ToList();
        }

    }
}