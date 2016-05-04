using System;
using System.Collections.Generic;
using EstatisticaFatec.Core.Models.DistribuicaoBinomial;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoBinomialApp
    {
        public List<decimal> RetornaK(decimal K, short tipo, decimal N)
        {
            switch (tipo)
            {
                case 0:
                    var lista = new List<decimal>();
                    var i = K;
                    while (i > 1)
                    {
                        i--;
                        lista.Add(i);
                    }
                    return lista;
                case 1:
                    return new List<decimal>()
                    {
                          K
                    };
                case 2:
                    var listaTop = new List<decimal>();
                    var j = K;
                    while (j < N)
                    {
                        j++;
                        listaTop.Add(j);
                    }
                    return listaTop;
                default:
                    throw new Exception("aa");
            }
        }

        public DistribuicaoBinomialEntity Build(DistribuicaoBinomialEntity entidade)
        {
            if (entidade.InputSemDefeito)
            {
                entidade.P = entidade.PInput / entidade.N;
                entidade.Q = 1 - entidade.P;
                entidade.K = RetornaK(entidade.KInput, entidade.TipoEntrada, entidade.N);
            }

            entidade.KProbabilidade = CalculoK(entidade);
            return entidade;
        }

        public List<decimal> CalculoK(DistribuicaoBinomialEntity entidade)
        {
            var listaCalculosK = new List<decimal>();
            foreach (var K in entidade.K)
            {
                var calculo = (decimal)((double)(entidade.N / K) * Math.Pow((double)entidade.P, (double)K) * Math.Pow((double)entidade.Q, (double)(entidade.N - K)));
                listaCalculosK.Add(calculo);
            }
            return listaCalculosK;
        }
    }
}
