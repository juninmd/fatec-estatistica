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
            return Math.Round((decimal)inputData.Sum() / (decimal)inputData.Count, 2);
        }

        public static List<decimal> Rol(List<decimal> inputData)
        {
            return inputData.OrderBy(q => q).ToList();
        }

        public static decimal Quadrado(decimal input)
        {
            return input * input;
        }

        /// <summary>
        /// (xi-`x)²
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="media"></param>
        /// <returns></returns>
        public static List<decimal> SomaTodosAoQuadrado(List<decimal> inputData, decimal media)
        {
            return inputData.Select(item => Quadrado(item - media)).ToList();
        }

        /// <summary>
        /// Retorna o valor E(xi-`x) / E(xi).length - 1
        /// </summary>
        /// <param name="inutData"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public static decimal DivideV2PorQuantidade(decimal inutData, int quantidade)
        {
            return inutData / (quantidade - 1);
        }


        /// <summary>
        /// (input / valorbase) * 100
        /// </summary>
        /// <param name="input"></param>
        /// <param name="valorBase"></param>
        /// <returns></returns>
        public static decimal Porcentagem(decimal input, decimal valorBase)
        {
            return Math.Round((input / valorBase) * 100, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal RaizQuadrada(decimal input)
        {
            return (decimal)Math.Sqrt((double)input);
        }


    }
}