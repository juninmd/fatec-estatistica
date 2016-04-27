using System;
using System.Collections.Generic;
using EstatisticaFatec.Core.Models.DistribuicaoBinomial;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoBinomialApp
    {
        public List<Tuple<decimal, decimal>> Fatorial(decimal K, short tipo, decimal N)
        {
            switch (tipo)
            {
                case 0:
                    var lista = new List<Tuple<decimal, decimal>>();
                    var i = K;
                    while (i > 1)
                    {
                        i--;
                        lista.Add(new Tuple<decimal, decimal>(i, 0));
                    }
                    return lista;
                case 1:
                    return new List<Tuple<decimal, decimal>>
                        {
                            new Tuple<decimal, decimal>(K,0)
                        };
                case 2:
                    var listaTop = new List<Tuple<decimal, decimal>>();
                    var j = K;
                    while (j < N)
                    {
                        j++;
                        listaTop.Add(new Tuple<decimal, decimal>(j, 0));
                    }
                    return listaTop;
            }
            return new List<Tuple<decimal, decimal>>
            {
                new Tuple<decimal, decimal>(1,2)
            };
        }

        public DistribuicaoBinomialEntity Build(DistribuicaoBinomialEntity entidade)
        {
            if (entidade.InputSemDefeito)
            {
                entidade.P = entidade.PInput / entidade.N;
                entidade.Q = 1 - entidade.P;
                entidade.K = Fatorial(entidade.KInput, entidade.TipoEntrada, entidade.N);
            }
            return entidade;
        }
    }
}
