using System.Collections.Generic;

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
    }
}