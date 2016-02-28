using EstatisticaFatec.Models.AleatoriaSimples;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstatisticaFatec.Core
{
    public class AleatoriaSimplesApp
    {
        public AleatoriaSimplesEntity Build(int populacao, int amostra)
        {
            return GetRandomNmbers(populacao, amostra);
        }
        /// <summary>
        /// Método responsável pela lógica de números aleatórios;
        /// </summary>
        /// <param name="populacao">Quantidade total de onde a amostra será baseada [População] Y= 100 </param>
        /// <param name="amostra">Quantidade da amostra X / Y * (Porcentagem) </param>
        /// <returns></returns>
        private AleatoriaSimplesEntity GetRandomNmbers(int populacao, int amostra)
        {
            var listaRandom = new List<int>();
            var i = 0;
            var randomNumber = 0;

            Random rnd = new Random();
            while (i < amostra)
            {
                randomNumber = rnd.Next(1, populacao + 1);

                while (listaRandom.Contains(randomNumber))
                {
                    randomNumber = rnd.Next(1, populacao + 1);
                }
                listaRandom.Add(randomNumber);
                i++;
            }
            return new AleatoriaSimplesEntity
            {
                Amostra = amostra,
                Populacao = populacao,
                Resultados = listaRandom.OrderBy(x=> x).ToList()
            };
        }
    }
}