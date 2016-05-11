using System;
using System.Collections.Generic;
using EstatisticaFatec.Core.Models.DistribuicaoBinomial;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoBinomialApp
    {
        public List<int> RetornaK(decimal K, short tipo, decimal N)
        {
            switch (tipo)
            {
                case 0:
                    var lista = new List<int>();
                    var i = (int)K;
                    while (i > 0)
                    {
                        i--;
                        lista.Add(i);
                    }
                    return lista;
                case 1:
                    return new List<int>()
                    {
                          (int)K
                    };
                case 2:
                    var listaTop = new List<int>();
                    var j = (int)K;
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
            if (entidade.InputSemDefeito == false)
            {
                entidade.P = (entidade.N - entidade.SucessoInput) / entidade.N;
            }
            else
            {
                entidade.P = entidade.SucessoInput / entidade.N;
            }
            entidade.Q = 1 - entidade.P;
            entidade.K = RetornaK(entidade.KInput, entidade.TipoEntrada, entidade.N);
            entidade.KProbabilidade = CalculoK(entidade);
            entidade.Media = Media(entidade);
            entidade.DesvioPadrao = DesvioPadrao(entidade);
            return entidade;
        }

        public List<decimal[]> CalculoK(DistribuicaoBinomialEntity entidade)
        {
            var listaCalculosK = new List<decimal[]>();
            foreach (var K in entidade.K)
            {
                /* N[fatorial] - K[fatorial] * (N - K [Fatorial]) */
                var calculobase = MathCoreApp.Fatorial(entidade.N) / (MathCoreApp.Fatorial(K) * MathCoreApp.Fatorial(entidade.N - K));
                var calculoA = Math.Pow((double)entidade.P, K);
                var calculoB = Math.Pow((double)entidade.Q, (double)(entidade.N - K));
                var calculoFinal = (decimal)(calculobase * calculoA * calculoB) * 100;
                listaCalculosK.Add(new[] { K, Math.Round(calculoFinal, 11) });
            }
            return listaCalculosK;
        }

        public decimal Media(DistribuicaoBinomialEntity entidade)
        {
            return Math.Round(entidade.N * entidade.P, 2);
        }
        public double DesvioPadrao(DistribuicaoBinomialEntity entidade)
        {
            return Math.Round(Math.Sqrt((double)(entidade.N * entidade.P * entidade.Q)), 2);
        }
    }
}
